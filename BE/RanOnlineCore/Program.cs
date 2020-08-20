using CronNET;
using Dapper.FastCrud;
using Framework;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RanOnlineCore.Action.CardModel;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Timers;

namespace RanOnlineCore
{
    public class Program
    {
        private static readonly CronDaemon cron_daemon = new CronDaemon();
        public static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000 * 60 * 0.5;
            timer.Enabled = true;
            CreateWebHostBuilder(args).Build().Run();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using(var cmd = new CheckCardAction())
            {
                cmd.Execute(ObjectContext.CreateContext(null, null));
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
