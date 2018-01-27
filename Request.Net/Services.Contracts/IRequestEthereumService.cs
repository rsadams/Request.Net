using System;
using System.Threading.Tasks;

namespace Request.Net.Services.Contracts
{
    /*
    * Interface of the RequestEthereumService
    */     
    public interface IRequestEthereumService
    {
        /*
        * Create a Request as the payee
        */
        Task<bool> CreateRequestAsPayee(string payer, int amountInitial, string data = "",
            string extension = "", string extensionParams = "",
            string options = "");

        /*
        * Accept a Request as the payer
        */
        Task<bool> Accept(string requestId, string options = "");

        /*
        * Cancel a Request as payer or payee
        */
        Task<bool> Cancel(string requestId, string options = "");

        /*
        * Pay a Request
        */
        void PaymentAction();

        /*
        * Refund a Request as payee
        */
        Task<bool> RefundAction(string requestId, int amount, string options = "");

        /*
        * Add subtracts as a payee
        */
        Task<bool> SubtractAction(string requestId, int amount, string options = "");

        /*
        * Add additionals to a Request as a payer
        */
        Task<bool> AdditionalAction(string requestId, int amount, string options = "");

        /*
        * Alias or RequestCoreServices.GetRequestEvents
        */
        void GetRequestEvents();

        /*
        * Decode data from an input transaction
        */
        void DecodeInputData();

        /*
        * Generate Nethereum method
        */
        void GenerateNethereumMethod();

        /*
        * Get Request events from the ciurrency contract
        */
        void GetRequestEventsCurrencyContractInfo();           
    }
}
