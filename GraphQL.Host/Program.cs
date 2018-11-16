using System;
using System.Net;
using GraphQL.API;
using GraphQL.API.Ioc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GraphQL.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
           CreateWebHost(args).Run();
            Console.ReadLine();
        }

        public static IWebHost CreateWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 6199);
                })
                .ConfigureServices(services => services.RegisterApiDependencies())
                .Build();
    }
}
