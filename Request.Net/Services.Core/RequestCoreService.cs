using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Request.Net.Services.External;
using Nethereum.Contracts;
using Nethereum.Web3;
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
        public RequestCoreService()
        {
            // Fetch our "singleton" Web3
            _web3 = Web3SingleService.Instance().Web3;

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
        public void GetCollectEstimation()
        {
            throw new NotImplementedException();      
        }

        /*
        * Get a Request via it's RequestId
        */
        public void GetRequest()
        {     
            throw new NotImplementedException();      
        }

        /*
        * Get a Request and method via the hash of a transaction
        */
        public void GetRequestByTransactionHash()
        {    
            throw new NotImplementedException();     
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