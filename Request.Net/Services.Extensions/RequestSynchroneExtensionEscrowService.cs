using System;
using Request.Net.Services.External;
using Nethereum.Contracts;

namespace Request.Net.Services.Extensions
{
    /*
    * Implementation of the RequestSynchroneExtensionEscrowService
    */  
    public class RequestSynchroneExtensionEscrowService : IRequestSynchroneExtensionEscrowService
    {
        private readonly Contract _contract;

        /*
         * Instantiate a new RequestEthereumService
        */
        public RequestSynchroneExtensionEscrowService()
        {
            // Fetch the contract from the required network via it's ABI
            _contract = Web3SingleService.Instance().Web3.Eth.GetContract("Abi", "ContractAddress");    
        } 
    }
}
