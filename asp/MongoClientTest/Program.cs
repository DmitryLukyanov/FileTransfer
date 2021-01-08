using System;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MongoClientTest.WebApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHost(args);

            Log.Info("Running application");
            host.Run();
        }

        static IWebHost CreateWebHost(string[] args)
        {
            var builder = CreateWebHostBuilder(args);
            var host = builder.Build();

            return host;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls(GetSiteUrls())
                .UseStartup<Startup>();
        }

        static string[] GetSiteUrls()
        {
            var urls = new List<string> {
                "http://127.0.0.1:50010/"
            };
            
            Log.Info($"Starting host on URLs: {Environment.NewLine}{String.Join(Environment.NewLine, urls)}");
            return urls.ToArray();
        }
    }
}
