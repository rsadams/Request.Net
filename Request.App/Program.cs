using System;
using Microsoft.Extensions.DependencyInjection;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
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
            var account = Account.LoadFromKeyStore(@"", "");

            // Add the required services to the DI container, we'll create an extension method for 
            // the various DI containers at a later date
            var serviceProvider = new ServiceCollection()
                .AddSingleton(new Web3("https://rinkeby.infura.io/2gunG0CoaeLOsBnYtqjC"))
                .AddSingleton<IRequestCoreService, RequestCoreService>()
                .AddSingleton<IRequestEthereumService, RequestEthereumService>()
                .AddSingleton<IRequestSynchroneExtensionEscrowService, RequestSynchroneExtensionEscrowService>()
                .BuildServiceProvider();

            // Resolve the instance from the container
            var requestCoreService = serviceProvider.GetService<IRequestCoreService>();

            // Run a few tests!
            Console.WriteLine("Version : " + requestCoreService.GetVersion().Result);
            Console.WriteLine("Current Request Number : " + requestCoreService.GetCurrentNumRequest().Result);
        }
    }
}
