using Nethereum.Contracts;
using Nethereum.Web3;

namespace Request.Net.Services.Extensions
{
    /*
    * Implementation of the RequestSynchroneExtensionEscrowService
    */  
    public class RequestSynchroneExtensionEscrowService : IRequestSynchroneExtensionEscrowService
    {
        private readonly Web3 _web3;
        private readonly Contract _contract;

        /*
         * Instantiate a new RequestEthereumService
        */
        public RequestSynchroneExtensionEscrowService(Web3 web3)
        {
            _web3 = web3;
        } 
    }
}
