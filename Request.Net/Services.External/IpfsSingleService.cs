using Request.Net.Services.External;

namespace Request.Net.Services.External
{
    /*
    * Implementation for the IPFSService.  It looks like these are used to provide
    * "Singleton" implementations in the TyopeScript code?  Probably better to use \
    * DI later..? 
    */
    public class IPFSSingleService
    {
        private static IPFSSingleService _instance;

        /*
         * Protected constructor
        */
        protected IPFSSingleService()
        {
            
        }

        /*
         * Use "Lazy" initialisation.  Simple but not thread safe. 
        */
        public static IPFSSingleService Instance()
        {
            if (_instance == null)
            {
                _instance = new IPFSSingleService();
            }

            return _instance;
        }
    }
}