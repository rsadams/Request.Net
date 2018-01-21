using Request.Net.Services.External;
using Request.Net.Services.Core;

using Nethereum.Web3;

namespace Request.Net.Services.External
{
    /*
    * Not really a singleton but for now we're following the patterns from the 
    * original SDK.
    */
    public class Web3SingleService
    {
        private static Web3SingleService _instance;
        public Web3 Web3 { get; private set; }

        /*
         * Protected constructor
        */
        protected Web3SingleService(string networkUrl)
        {
            Web3 = new Nethereum.Web3.Web3(networkUrl);
        }

        /*
         * Initialise the singleton 
        */
        public void Init(string networkUrl)
        {
            _instance = new Web3SingleService(networkUrl);
        }

        /*
         * Return the "singleton" instance
        */
        public static Web3SingleService Instance()
        {
            return _instance;
        }
    }
}