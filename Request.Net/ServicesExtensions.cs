/*
 * Description : Looks like this is designed to parse the artifact json and return some
 * important properties.  Address, network, etc..
 * 
 * We're probably going to have to wrap the JSON in a DTO..
 * 
*/

using Request.Net.Services.Extensions;

namespace Request.Net
{
    public static class ServicesExtensions
    {
        /*
         * Appears to instantiate a new services based on the provided address?
         */
        public static IRequestSynchroneExtensionEscrowService GetServiceFromAddress(string address)
        {
            return null;
        }
    }
}