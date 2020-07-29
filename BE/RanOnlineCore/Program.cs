using CronNET;
using Framework;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RanOnlineCore.Action.AttackAction;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace RanOnlineCore
{
    public class Program
    {
        private static readonly CronDaemon cron_daemon = new CronDaemon();
        public static void Main(string[] args)
        {
            var t = new ThreadStart(task);
            cron_daemon.AddJob("*/2 * * * *", t);
            cron_daemon.Start();
            CreateWebHostBuilder(args).Build().Run();

        }
        private static void task()
        {
            try
            {
                ObjectContext.Messages = new Dictionary<string, long>();
                using (var cmd = new AttackElementAction())
                {
                    cmd.Execute(ObjectContext.CreateContext(null,null));
                }
            }
            catch (Exception)
            {

            }   
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
