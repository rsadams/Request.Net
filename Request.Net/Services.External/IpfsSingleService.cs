using Request.Net.Services.External;

namespace Request.Net.Services.External
{
    /*
    * Not really a singleton but for now we're following the patterns from the 
    * original SDK.
    */
    public class IpfsSingleService
    {
        private static IpfsSingleService _instance;

        /*
         * Protected constructor
        */
        protected IpfsSingleService()
        {
        }

        /*
         * Initialise the "singleton" 
        */
        public void Init()
        {
            _instance = new IpfsSingleService(); 
        }

        /*
         * Return the "singleton" instance
        */
        public static IpfsSingleService Instance()
        {
            return _instance;
        }
    }
}