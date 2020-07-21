using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class ZaloArticle
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Cover
        {
            public string cover_type { get; set; }
            public string photo_url { get; set; }
            public string status { get; set; }

        }

        public class Body
        {
            public string type { get; set; }
            public string url { get; set; }
            public string caption { get; set; }
            public string content { get; set; }

        }

        public class Cite
        {
            public string url { get; set; }
            public string lablel { get; set; }

        }

        public class Article
        {
            public string id { get; set; }
            public string type { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public Cover cover { get; set; }
            public string description { get; set; }
            public string status { get; set; }
            public List<Body> body { get; set; }
            public List<object> related_medias { get; set; }
            public string comment { get; set; }
            public Cite cite { get; set; }

        }


    }
}
