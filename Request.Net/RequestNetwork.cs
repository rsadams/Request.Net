using System;
using Request.Net.Services.Core;
using Request.Net.Services.Contracts;

namespace Request.Net
{
    public class RequestNetwork
    {
        private readonly IRequestEthereumService _requestEthereumService;
        private readonly IRequestCoreService _requestCoreService;

        /*
        * Instantiate a new RequestNetwork class.
        */
        public RequestNetwork()
        {
            _requestEthereumService = new RequestEthereumService();
            _requestCoreService = new RequestCoreService();
        }
    }    
}