using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class Sender
    {
        public string id { get; set; }

    }

    public class Recipient
    {
        public string id { get; set; }

    }

    public class Message
    {
        public string msg_id { get; set; }
        public string text { get; set; }
    }

    public class ZaloReceiveMessage
    {
        public string app_id { get; set; }
        public Sender sender { get; set; }
        public string user_id_by_app { get; set; }
        public Recipient recipient { get; set; }
        public string event_name { get; set; }
        public Message message { get; set; }
        public string timestamp { get; set; }

    }
}
