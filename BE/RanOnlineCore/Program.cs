using CronNET;
using Framework;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;

namespace RanOnlineCore
{
    public class Program
    {
        private static readonly CronDaemon cron_daemon = new CronDaemon();
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(serverOptions =>
                {
                    serverOptions.Listen(IPAddress.Loopback, 5000); //HTTP port
                    serverOptions.Listen(IPAddress.Loopback, 5443); //HTTPS port
                });

    }
}
