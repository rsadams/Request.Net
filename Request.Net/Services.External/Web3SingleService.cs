using Request.Net.Services.External;
using Request.Net.Services.Core;

namespace Request.Net.Services.External
{
    /*
    * Implementation for the Web3SingleService.  It looks like these are used to provide
    * "Singleton" implementations in the TypeScript code.  Probably better to use DI later?
    */
    public class Web3SingleService
    {
        private static Web3SingleService _instance;

        /*
         * Protected constructor
        */
        protected Web3SingleService()
        {
        }

        /*
         * Use "Lazy" initialisation.  Simple but not thread safe. 
        */
        public static Web3SingleService Instance()
        {
            if (_instance == null)
            {
                _instance = new Web3SingleService();
            }

            return _instance;
        }
    }
}