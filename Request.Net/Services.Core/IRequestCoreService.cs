using System;
using System.Threading.Tasks;

namespace Request.Net.Services.Core
{
    /*
     * Interface of the RequestCoreService
    */  
    public interface IRequestCoreService
    {
        /*
         * Get the number of the last request (N.B: number !== id)
        */
        Task<UInt64> GetCurrentNumRequest();

        /*
         * Get the version of the contract
        */
        Task<UInt32> GetVersion();

        /*
         * Get the estimation (in Wei) needed to create the request
        */
        Task<UInt64> GetCollectEstimation(int expectedAmount, string currencyContract, string extension = "");

        /*
         * Get a Request via it's RequestId
        */
        Task<Request> GetRequest(string requestId);

        /*
         * Get a Request's events
        */
        void GetRequestEvents();

        /*
         * Get a list of events associated with an address
        */
        void GetRequestsByAddress();

        void GetIPFSFile();       
    }
}
