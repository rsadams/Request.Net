using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Util;
using Newtonsoft.Json.Linq;

namespace Request.Net.Services.Core
{
    /*
    * Implementation of the RequestCoreService
    */
    public class RequestCoreService : IRequestCoreService
    {
        private readonly Web3 _web3;
        private readonly Contract _contract;

        /*
        * Instantiate a new RequestCoreService.
        */ 
        public RequestCoreService(Web3 web3)
        {
            _web3 = web3;

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
        * Get the number of the last request (N.B: number !== id)
        */ 
        public async Task<UInt64> GetCurrentNumRequest()
        {
            var function = _contract.GetFunction("numRequests");
            return await function.CallAsync<UInt64>();
        }

        /*
        * Get the version of the contract
        */
        public async Task<UInt32> GetVersion() 
        {
            var function = _contract.GetFunction("VERSION");
            return await function.CallAsync<UInt32>();
        }

        /*
        * Get the estimation (in Wei) needed to create the request
        */
        public async Task<UInt64> GetCollectEstimation(int expectedAmount, string  currencyContract, string extension = "")
        {
            var addressUtil = new AddressUtil(); 

            if (!addressUtil.IsChecksumAddress(currencyContract))
            {
                throw new ArgumentException("currencyContract must be a valid ETH address");   
            }

            if (!string.IsNullOrEmpty(extension) && !addressUtil.IsChecksumAddress(extension))
            {
                throw new ArgumentException("extension must be a valid ETH address");
            }

            var function = _contract.GetFunction("getCollectEstimation");
            return await function.CallAsync<UInt64>(expectedAmount, currencyContract);
        }

        /*
        * Get a Request via it's RequestId
        */
        public async Task<Request> GetRequest(string requestId)
        {
            Request request = null;

            var function = _contract.GetFunction("requests");
            try
            {
                request = await function.CallDeserializingToObjectAsync<Request>(Utils.HexStringToByte32(requestId));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);    
            }

            return request;
        }

        /*
        * Get a Request's events
        */
        public void GetRequestEvents()
        {
            throw new NotImplementedException();
        }

        /*
        * Get a list of events associated with an address
        */
        public void GetRequestsByAddress()
        {
            throw new NotImplementedException();
        }

        public void GetIPFSFile()
        {
            throw new NotImplementedException(); 
        }
    }
}