using Request.Net.Services.Core;
using Request.Net.Services.Contracts;
using Request.Net.Services.Extensions;
using Request.Net.Services.External;

namespace Request.Net
{
    public class RequestNetwork
    {
        public IRequestCoreService RequestCoreService { get; private set; }
        public IRequestEthereumService RequestEthereumService { get; private set; }
        public IRequestSynchroneExtensionEscrowService RequestSynchroneExtensionEscrowService { get; private set; }

        /*
        * Instantiate a new RequestNetwork class.
        */
        public RequestNetwork(string networkUrl)
        {
            // Initialise the Web3 singleton
            Web3SingleService.Instance().Init(networkUrl);

            // Initialise the IpfsSingleton
            IpfsSingleService.Instance().Init();

            // Initialise the service interfaces
            RequestCoreService = new RequestCoreService();
            RequestEthereumService = new RequestEthereumService();
            RequestSynchroneExtensionEscrowService = new RequestSynchroneExtensionEscrowService();
        }
    }    
}