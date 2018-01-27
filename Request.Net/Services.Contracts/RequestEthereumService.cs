using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Request.Net.Services.Core;
using Nethereum.Web3;
using Nethereum.Contracts;
using Newtonsoft.Json.Linq;
using Nethereum.Util;
using Newtonsoft.Json;

namespace Request.Net.Services.Contracts
{
    /*
    * Implementation of the RequestEthereumService
    */
    public class RequestEthereumService : IRequestEthereumService
    {
        private readonly Web3 _web3;
        private IRequestCoreService _requestCoreService;
        private readonly Contract _contract;

        //Temporary variabler until the account can be pulled in from a json file?
        private readonly string _defaultAccount;

        /*
        * Instantiate a new RequestEthereumService
        */ 
        public RequestEthereumService(Web3 web3, IRequestCoreService requestCoreService)
        {
            _web3 = web3;
            _requestCoreService = requestCoreService;
            _defaultAccount = "0x12890d2cce102216644c59dae5baed380d84830c";

            // This de-serialisation from an embedded resource is VERY temporary.  Please don't judge :)
            var assembly = Assembly.GetExecutingAssembly();
            var streamReader = new StreamReader(assembly.GetManifestResourceStream("Request.Net.Artifacts.RequestCore.json"));

            // Read the JSON in to a JObject
            var artifact = JObject.Parse(streamReader.ReadToEnd());
            var abi = artifact["abi"].ToString();
            var contractAddress = artifact["networks"]["rinkeby"]["address"].ToString();

            _contract = _web3.Eth.GetContract(abi, contractAddress);
        }

        /*
        * Create a Request as the payee
        */
        public async Task<bool> CreateRequestAsPayee(string payer, int amountInitial, string data = "",
            string extension = "", string extensionParams = "", 
            string options = "")
        {
            // Retrieve the default account
            JObject optionsObject = (JObject)JsonConvert.DeserializeObject(options) ?? new JObject();
            optionsObject.TryGetValue("from", out JToken from);

            string account = from?.ToString() ?? "0x12890d2cce102216644c59dae5baed380d84830c";

            // Validate amount is a positive integer
            if (amountInitial < 0)
            {
                throw new ArgumentException("amountInitial must be a positive integer");
            }

            // Validate that payer is a valid ETH address
            var addressUtil = new AddressUtil();
            if (!addressUtil.IsChecksumAddress(payer))
            {
                throw new ArgumentException("payer must be a valid eth address");
            }

            // Validate that extension is a valid ETH address
            if (!String.IsNullOrEmpty(extension) && !addressUtil.IsChecksumAddress(extension))
            {
                throw new ArgumentException("extension must be a valid eth address");
            }

            // Validate that extension params length is less then 9
            JObject extensionParamsObject = (JObject)JsonConvert.DeserializeObject(extensionParams) ?? new JObject();

            if (extensionParamsObject.Count > 9)
            {
                throw new ArgumentException("extensionParams must be less than 9");
            }

            // Validate that account and payer are different
            if (String.Equals(payer, account))
            {
                throw new ArgumentException("from must be different than payer");
            }

            // Get the amount to collect
            var requestCoreService = new RequestCoreService(_web3);
            var value = await requestCoreService.GetCollectEstimation(amountInitial, _contract.Address, extension);
            optionsObject.Add("value", value);

            // Parse extension params

            // Add the Ipfs file

            return true;
        }

        /*
        * Accept a Request as the payer
        */
        public async Task<bool> Accept(string requestId, string options = "")
        {
            // Retrieve the default account
            // Still need to actually get the default account ;)
            JObject optionsObject = (JObject)JsonConvert.DeserializeObject(options) ?? new JObject();
            optionsObject.TryGetValue("from", out JToken from);

            string account = from?.ToString() ?? _defaultAccount;

            // Get the request
            var request = await _requestCoreService.GetRequest(requestId);

            if (request.State != (uint)State.Created)
            {
                throw new ArgumentException("request state is not \'created\'");
            }

            if (!String.Equals(account, request.Payer))
            {
                throw new ArgumentException("account must be the payer");
            }

            return true;
        } 

        /*
        * Cancel a Request as payer or payee
        */
        public async Task<bool> Cancel(string requestId, string options = "")
        {
            // Retrieve the default account
            // Still need to actually get the default account ;)
            JObject optionsObject = (JObject)JsonConvert.DeserializeObject(options) ?? new JObject();
            optionsObject.TryGetValue("from", out JToken from);

            string account = from?.ToString() ?? _defaultAccount;

            // Get the request
            var request = await _requestCoreService.GetRequest(requestId);

            if (!String.Equals(account, request.Payer) && !String.Equals(account, request.Payee))
            {
                throw new ArgumentException("account must be the payer or the payee");
            }

            if (String.Equals(account, request.Payer) && request.State != (uint)State.Created)
            {
                throw new ArgumentException("payer can only cancel request in state \'created\'");
            }

            if (String.Equals(account, request.Payee) && request.State == (uint)State.Cancelled)
            {
                throw new ArgumentException("payee cannot cancel requests that are already \'canceled\'");
            }

            if (!request.Balance.IsZero)
            {
                throw new ArgumentException("impossible to cancel a Request with a balance != 0");
            }

            return true;
        }

        /*
        * Pay a Request
        */
        public void PaymentAction()
        {     
            throw new NotImplementedException();      
        }

        /*
        * Refund a Request as payee
        */
        public async Task<bool> RefundAction(string requestId, int amount, string options = "")
        {
            // Retrieve the default account
            // Still need to actually get the default account ;)
            JObject optionsObject = (JObject)JsonConvert.DeserializeObject(options) ?? new JObject();
            optionsObject.TryGetValue("from", out JToken from);

            string account = from?.ToString() ?? _defaultAccount;

            // Get the request
            var request = await _requestCoreService.GetRequest(requestId);

            optionsObject.TryGetValue("value", out JToken value);
            if (value.ToObject<int>() < 0)
            {
                throw new ArgumentException("amount must be a positive integer");
            }

            if (request.State != (uint) State.Accepted)
            {
                throw new ArgumentException("request must be accepted");
            }

            if (!String.Equals(account, request.Payee))
            {
                throw new ArgumentException("account must be payee");
            }

            return true;
        }

        /*
        * Add subtracts as a payee
        */
        public async Task<bool> SubtractAction(string requestId, int amount, string options = "")
        {
            // Retrieve the default account
            // Still need to actually get the default account ;)
            JObject optionsObject = (JObject)JsonConvert.DeserializeObject(options) ?? new JObject();
            optionsObject.TryGetValue("from", out JToken from);

            string account = from?.ToString() ?? _defaultAccount;

            // Get the request
            var request = await _requestCoreService.GetRequest(requestId);

            if (amount < 0 )
            {
                throw new ArgumentException("amount must be a positive integer");
            }

            if (amount > request.ExpectedAmount)
            {
                throw new ArgumentException("amount must be equal or less than amount expected");
            }

            if (request.State == (uint) State.Cancelled)
            {
                throw new ArgumentException("request must be accepted or created");
            }

            if (!String.Equals(account, request.Payee))
            {
                throw new ArgumentException("account must be payee");
            }

            return true;
        }

        /*
        * Add additionals to a Request as a payer
        */
        public async Task<bool> AdditionalAction(string requestId, int amount, string options = "")
        {
            // Retrieve the default account
            // Still need to actually get the default account ;)
            JObject optionsObject = (JObject)JsonConvert.DeserializeObject(options) ?? new JObject();
            optionsObject.TryGetValue("from", out JToken from);

            string account = from?.ToString() ?? _defaultAccount;

            // Get the request
            var request = await _requestCoreService.GetRequest(requestId);

            if (amount < 0)
            {
                throw new ArgumentException("amount must be a positive integer");
            }

            if (request.State == (uint)State.Cancelled)
            {
                throw new ArgumentException("request must be accepted or created");
            }

            if (!String.Equals(account, request.Payer))
            {
                throw new ArgumentException("account must be payer");
            }

            return true;
        }

        /*
        * Alias or RequestCoreServices.GetRequestEvents
        */
        public void GetRequestEvents()
        {
            throw new NotImplementedException();
        }

        /*
        * Decode data from an input transaction
        */
        public void DecodeInputData()
        {
            throw new NotImplementedException();
        }

        /*
        * Generate Nethereum method
        */
        public void GenerateNethereumMethod()
        {
            throw new NotImplementedException();
        }

        /*
        * Get Request events from the ciurrency contract
        */
        public void GetRequestEventsCurrencyContractInfo()
        {
            throw new NotImplementedException();
        }    
    }
}