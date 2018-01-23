using System;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.Web3;
using Request.Net;
using Request.Net.Services.Contracts;
using Request.Net.Services.Core;
using Request.Net.Services.Extensions;

namespace Request.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an Ethereum account from a local KeyStore
            // var account = Account.LoadFromKeyStore(@"", "");

            // Add the required services to the DI container, we'll create an extension method for 
            // the various DI containers at a later date
            var serviceProvider = new ServiceCollection()
                .AddSingleton(new Web3("https://rinkeby.infura.io/2gunG0CoaeLOsBnYtqjC"))
                .AddSingleton<IRequestCoreService, RequestCoreService>()
                .AddSingleton<IRequestEthereumService, RequestEthereumService>()
                .AddSingleton<IRequestSynchroneExtensionEscrowService, RequestSynchroneExtensionEscrowService>()
                .AddSingleton<IRequestService, RequestService>()
                .BuildServiceProvider();

            // Resolve the service instances from the container
            var requestService = serviceProvider.GetService<IRequestService>();
            var requestCoreService = serviceProvider.GetService<IRequestCoreService>();
            var requestEthereumService = serviceProvider.GetService<IRequestEthereumService>();

            // Run a few tests!
            Console.WriteLine("Version() : " + requestCoreService.GetVersion().Result);
            Console.WriteLine("CurrentRequestNumber() : " + requestCoreService.GetCurrentNumRequest().Result);
            Console.WriteLine("GetCollectEstimation() : " + requestCoreService.GetCollectEstimation(1000, "0x0d5D6c5aB28737C182B9e67194451c2C6BcA8623", "").Result);

            Console.WriteLine("GetRequest() : " + requestService.GetCompleteRequestById("0xa0f9348269095faeb497d8de0b892d542de6d48e3583363b8c77542561f4e375").Result);
            Console.WriteLine("GetRequestByTransactionHash() : " + requestService.GetCompleteRequestByTransactionHash("0x0d68a139f36e5e809dce06ab58aa8bd6f74f689c2be45c09ecb0d5f601700ec6").Result);
        }
    }
}
    