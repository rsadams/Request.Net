using System;
using Request.Net;

namespace Request.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialising RequestNetwork");
            var requestNetwork = new RequestNetwork("https://rinkeby.infura.io/2gunG0CoaeLOsBnYtqjC");

            Console.WriteLine("Version : " + requestNetwork.RequestCoreService.GetVersion().Result);
            Console.WriteLine("Current Request Number : " + requestNetwork.RequestCoreService.GetCurrentNumRequest().Result);
        }
    }
}
