using System;
using System.IO;
using System.Reflection;
using Request.Net.Services.Core;
using Nethereum.Web3;
using Nethereum.Contracts;
using Newtonsoft.Json.Linq;

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

        /*
        * Instantiate a new RequestEthereumService
        */ 
        public RequestEthereumService(Web3 web3, IRequestCoreService requestCoreService)
        {
            _web3 = web3;
            _requestCoreService = requestCoreService;

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
        public void CreateRequestAsPayee(string payer, int amountInitial, string data = "", 
                                         string extension = "", string extensionParams = "", 
                                         string options = "")
        {
            return;
        }

        /*
        * Accept a Request as the payer
        */
        public void Accept() 
        {
            throw new NotImplementedException();      
        }

        /*
        * Cancel a Request as payer or payee
        */
        public void Cancel()
        {
            throw new NotImplementedException();      
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
        public void RefundAction()
        {    
            throw new NotImplementedException();     
        }

        /*
        * Add subtracts as a payee
        */
        public void SubtractAction()
        {
            throw new NotImplementedException();
        }

        /*
        * Add additionals to a Request as a payer
        */
        public void AdditionalAction()
        {
            throw new NotImplementedException();
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