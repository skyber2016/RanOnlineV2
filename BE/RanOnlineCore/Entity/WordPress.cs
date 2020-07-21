using Framework;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Entity
{
    public class WordPressBase
    {
        protected static ObjectContext Context { get; set; }
        public WordPressBase()
        {
            if (Context == null)
            {
                Context = ObjectContext.CreateContext(null, null);
            }
        }
    }
    [Table("wp_posts")]
    public class Posts : WordPressBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int post_author { get; set; }
        public DateTime post_date { get; set; }
        public DateTime post_date_gmt { get; set; }
        public string post_content { get; set; }
        public string post_title { get; set; }
        public string post_excerpt { get; set; }
        public string post_status { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public string post_password { get; set; }
        public string post_name { get; set; }
        public string to_ping { get; set; }
        public string pinged { get; set; }
        public DateTime post_modified { get; set; }
        public DateTime post_modified_gmt { get; set; }
        public string post_content_filtered { get; set; }
        public int post_parent { get; set; }
        public string guid { get; set; }
        public int menu_order { get; set; }
        public string post_type { get; set; }
        public string post_mime_type { get; set; }
        public int comment_count { get; set; }

        private IEnumerable<PostMeta> _PostMeta;
        public IEnumerable<PostMeta> PostMeta
        {
            get
            {
                if(this._PostMeta == null)
                {
                    this._PostMeta = Context.Factory.Query("wp_postmeta").Where("post_id", this.ID)
                    .Get<PostMeta>();
                }
                return this._PostMeta;
            }
        }
    }

    public class PostMeta : WordPressBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int meta_id { get; set; }
        public int post_id { get; set; }
        public string meta_key { get; set; }
        public string meta_value { get; set; }

        private Posts _Posts { get; set; }
        public Posts Posts
        {
            get
            {
                if (this._Posts == null)
                {
                    this._Posts = Context.Factory.Query("wp_posts").Where("ID", this.post_id)
                    .FirstOrDefault<Posts>();
                }
                return this._Posts;
            }
        }

        private IDictionary<string,PostMeta> _masterData { get; set; }
        public IDictionary<string, PostMeta> Master
        {
            get
            {
                if (this._masterData == null)
                {
                    var data = Context.Factory.Query("wp_postmeta").Where("post_id", this.post_id).Get<PostMeta>();
                    this._masterData = data.ToDictionary(x => x.meta_key);
                }
                return this._masterData;
            }
        }
    }
}
