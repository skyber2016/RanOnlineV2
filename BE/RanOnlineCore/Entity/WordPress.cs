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
    }

    public class PostMeta : WordPressBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int meta_id { get; set; }
        public int post_id { get; set; }
        public string meta_key { get; set; }
        public string meta_value { get; set; }

    }

    public class DTOPosts
    {
        public int Id { get; set; }
        public int MenuOrder { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public string Url { get; set; }
    }
    public class DTOGetPosts : Posts
    {
        public string Thumb { get; set; }
    }
    public class Term
    {
        public int term_id { get; set; }
        public string name { get; set; }
    }
    public class TermRelationship
    {
        public int object_id { get; set; }
        public int term_taxonomy_id { get; set; }
    }

    public class PostFriend
    {
        public int object_id { get; set; }
        public string category_name { get; set; }
        public string post_title { get; set; }
        public string post_name { get; set; }
        public DateTime post_date { get; set; }
    }

}
