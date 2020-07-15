using Framework;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RanOnlineCore.Entity;
using RanOnlineCore.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZaloCSharpSDK;

namespace RanOnlineCore.Framework
{
    public class RabbitMQConfiguration : BackgroundService
    {
        private readonly string  Queue = "hoangduy";
        private readonly string Exchange = "zalo.webhook";
        private readonly string RoutingKey = "zalo";
        private IConnection Connection;
        private IModel Channel;
        private ObjectContext Context { get; set; }
        public RabbitMQConfiguration()
        {
            InitRabbitMQ();
        }
        private void InitRabbitMQ()
        {
            Context = ObjectContext.CreateContext(null, null);
            var factory = new ConnectionFactory()
            {
                HostName = this.Context.GlobalConfig.RabbitHost,
                UserName = this.Context.GlobalConfig.RabbitUsername,
                Password = this.Context.GlobalConfig.RabbitPassword,
                Port = this.Context.GlobalConfig.RabbitPort
            };

            // create connection  
            Connection = factory.CreateConnection();

            // create channel  
            Channel = Connection.CreateModel();
            
            Channel.ExchangeDeclare(Exchange, ExchangeType.Direct);
            Channel.QueueDeclare(Queue, false, false, false, null);
            Channel.QueueBind(Queue, Exchange, RoutingKey, null);
            Channel.BasicQos(0, 1, false);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(Channel);
            consumer.Received += Consumer_Received;


            Channel.BasicConsume(Queue, false, consumer);
            return Task.CompletedTask;

        }
        private static Random Rand { get; set; }
        private static List<string> TextRand { get; set; }
        private void Consumer_Received(object model, BasicDeliverEventArgs ea)
        {
            if(Rand == null)
            {
                Rand = new Random();
            }
            if(TextRand == null)
            {
                TextRand = new List<string>
                {
                        "Đời lắm trò hay: Loay hoay toàn gặp chó.",
                        "Tao biết sống là phải tàn ác \nVà phải cảnh giác với những con chó như tụi mày.",
                        "Thật sự tao rất KHINH những ai bắt đầu việc nhận xét tao bằng ba từ “NHÌN LÀ BIẾT”",
                        "Sống trên đời phải biết mình là ai\nĐừng vì “sỹ diện” mà làm khổ cha mẹ\nĐừng vì “tiền bạc” mà bán rẻ lương tâm\nĐừng vì “hư danh” mà khinh mạt người đời\nĐừng nghĩ mình “khôn ngoan” mà lọc lừa dối trá…",
                };
            }
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var result = JsonConvert.DeserializeObject<ZaloReceiveMessage>(message);
            if(result.event_name == ZaloEvent.UserSendText)
            {
                var messageText = result.message.text;
                if (messageText.StartsWith("#tkb"))
                {
                    this.Context.ZaloClient.sendTextMessageToUserId(result.sender.id, TextRand[Rand.Next(0,TextRand.Count -1)]);
                }
                if (messageText.StartsWith("#add"))
                {
                    var textRep = messageText.Replace("#add", "");
                    TextRand.Add(textRep);
                    this.Context.ZaloClient.sendTextMessageToUserId(result.sender.id, "ok");
                }
            }
            
            Channel.BasicAck(ea.DeliveryTag, false);
        }
    }
}
