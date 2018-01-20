using System;

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
        void CreateRequestAsPayee();

        /*
        * Accept a Request as the payer
        */
        void Accept();

        /*
        * Cancel a Request as payer or payee
        */
        void Cancel();

        /*
        * Pay a Request
        */
        void PaymentAction();

        /*
        * Refund a Request as payee
        */
        void RefundAction();

        /*
        * Add subtracts as a payee
        */
        void SubtractAction();

        /*
        * Add additionals to a Request as a payer
        */
        void AdditionalAction();

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
        void GenerateNethereymMethod();

        /*
        * Get Request events from the ciurrency contract
        */
        void GetRequestEventsCurrencyContractInfo();           
    }
}
