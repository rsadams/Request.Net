/*
 * Description : Looks like this is designed to parse the artifact json and return some
 * important properties.  Address, network, etc..
 * 
 * We're probably going to have to wrap the JSON in a DTO..
 * 
*/

using Request.Net.Services.Contracts;

namespace Request.Net
{
    public static class ServicesContracts
    {
        /*
         * Appears to instantiate a new services based on the provided address?
         */
        public static IRequestEthereumService GetServiceFromAddress(string address)
        {
            return new RequestEthereumService();
        }
    }
}