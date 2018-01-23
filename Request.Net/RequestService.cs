using System;
using System.Threading.Tasks;
using Nethereum.Web3;
using Request.Net.Services.Contracts;
using Request.Net.Services.Core;

namespace Request.Net
{
    /*
     * We're going to experiment with moving some SDK functions up a level out of the core to leaving a 1-1
     * mapping between contract services and the underlying Solidity contracts.  Hopefully this'll help
     * encapsulate the business logic and ensure calls are only made down the stack. Not across.
    */
    public class RequestService : IRequestService
    {
        private readonly Web3 _web3; 
        private readonly IRequestCoreService _requestCoreService;
        private readonly IRequestEthereumService _requestEthereumService;

        public RequestService(Web3 web3, IRequestCoreService requestCoreService, IRequestEthereumService requestEthereumService)
        {
            _web3 = web3;
            _requestCoreService = requestCoreService;
            _requestEthereumService = requestEthereumService;
        }

        public async Task<Request> GetCompleteRequestById(string requestId)
        {
            // Fetch the core request
            var request = await _requestCoreService.GetRequest(requestId);

            // Fetch the associated currency contract (Default to ETH for now)
            var currencyContract = _requestEthereumService;
            // var contractInfo = currencyContract.GetRequestEventsCurrencyContractInfo();

            // Fetch the associated extension contract (Ignored for now)

            // Get Ipfs data if needed (Ignored for now)

            return request;
        }

        public async Task<Request> GetCompleteRequestByTransactionHash(string transactionHash)
        {
            // Fetch the original transaction
            var transaction = await _web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(transactionHash);

            // Fetch the associated currency contract (Default to ETH for now)
            var currencyContract = _requestEthereumService;

            // Fetch the associated extension contract (Ignored for now)

            // Get the transaction receipt
            var transactionReceipt = await _web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionHash);

            // Is it already mined?
            if (transactionReceipt != null)
            {
                if (transactionReceipt.Status.HexValue != "0x1")
                {

                }
            }

            // No let's try to call it

            return new Request();
        }
    }
}
