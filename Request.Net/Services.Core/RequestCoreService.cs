using System;

namespace Request.Net.Services.Core
{
    /*
    * Implementation of the RequestCoreService
    */ 
    public class RequestCoreService : IRequestCoreService
    {
        protected string addressRequestCore;

        /*
        * Instantiate a new RequestCoreService
        */ 
        public RequestCoreService()
        {
            throw new NotImplementedException();
        }

        /*
        * Get the number of the last request (N.B: number !== id)
        */ 
        public void GetCurrentNumRequest()
        {
            throw new NotImplementedException();
        }

        /*
        * Get the version of the contract
        */
        public void GetVersion() 
        {
            throw new NotImplementedException();      
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