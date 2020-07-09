using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace RanOnlineCore.Entity
{
    
    /// <summary>
    /// A class which represents the Web_news table.
    /// </summary>
	[Table("Web_news")]
    public partial class Webnew
    {
        public virtual string news_title { get; set; }
        public virtual string news_autor { get; set; }
        public virtual string news_category { get; set; }
        public virtual string news_context { get; set; }
        public virtual string news_date { get; set; }
        public virtual string news_id { get; set; }
    }

    /// <summary>
    /// A class which represents the backVote table.
    /// </summary>
	[Table("backVote")]
    public partial class backVote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int id { get; set; }
        public virtual string link { get; set; }
        public virtual string username { get; set; }
        public virtual int? votetime { get; set; }
    }

    /// <summary>
    /// A class which represents the BlockAddress table.
    /// </summary>
	[Table("BlockAddress")]
    public partial class BlockAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int BlockIdx { get; set; }
        public virtual string _BlockAddress { get; set; }
        public virtual string BlockReason { get; set; }
        public virtual DateTime? BlockDate { get; set; }
    }

    /// <summary>
    /// A class which represents the donator_itemlst table.
    /// </summary>
	[Table("donator_itemlst")]
    public partial class donatoritemlst
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ItemNum { get; set; }
        public virtual string ItemName { get; set; }
        public virtual byte[] ItemData { get; set; }
    }

    /// <summary>
    /// A class which represents the Auctions_Mail table.
    /// </summary>
	[Table("Auctions_Mail")]
    public partial class AuctionsMail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long MailNum { get; set; }
        public virtual string MailFrom { get; set; }
        public virtual string MailTo { get; set; }
        public virtual long? MailToNum { get; set; }
        public virtual long? MailUserNum { get; set; }
        public virtual string MailContext { get; set; }
        public virtual long MailAuction { get; set; }
        public virtual string MailWhoBought { get; set; }
        public virtual string MailSubject { get; set; }
        public virtual byte[] MailData { get; set; }
        public virtual string MailId { get; set; }
        public virtual int MailRead { get; set; }
        public virtual string MailDate { get; set; }
    }

    /// <summary>
    /// A class which represents the Auctions_Items table.
    /// </summary>
	[Table("Auctions_Items")]
    public partial class AuctionsItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ItemNum { get; set; }
        public virtual string ItemName { get; set; }
        public virtual string ItemDescription { get; set; }
        public virtual string ItemSeller { get; set; }
        public virtual long ItemPrice { get; set; }
        public virtual int ItemType { get; set; }
        public virtual string ItemDate { get; set; }
        public virtual string ItemId { get; set; }
        public virtual string ItemKey { get; set; }
        public virtual byte[] ItemData { get; set; }
        public virtual int? ItemLvl { get; set; }
        public virtual long? ItemSellerNum { get; set; }
    }

    /// <summary>
    /// A class which represents the IPInfo table.
    /// </summary>
	[Table("IPInfo")]
    public partial class IPInfo
    {
        public virtual string IpAddress { get; set; }
        public virtual int UserNum { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int IdxIP { get; set; }
        public virtual int? UseAvailable { get; set; }
    }

    /// <summary>
    /// A class which represents the WEB_DOWNLOAD table.
    /// </summary>
	[Table("WEB_DOWNLOAD")]
    public partial class WEBDOWNLOAD
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        public virtual string NAME { get; set; }
        public virtual string DOWNLOADURL { get; set; }
        public virtual int? EXPLAIN { get; set; }
        public virtual DateTime? ADDTIME { get; set; }
    }

    /// <summary>
    /// A class which represents the CheckId table.
    /// </summary>
	[Table("CheckId")]
    public partial class CheckId
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Num { get; set; }
        [Key]
        public virtual string Id { get; set; }
        public virtual DateTime? CreateDate { get; set; }
    }

    /// <summary>
    /// A class which represents the FullUserInfo table.
    /// </summary>
	[Table("FullUserInfo")]
    public partial class FullUserInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int UserNum { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserID { get; set; }
        public virtual string UserPass { get; set; }
        public virtual string UserPass2 { get; set; }
        public virtual string BodyID { get; set; }
        public virtual string Sex { get; set; }
        public virtual string Email { get; set; }
        public virtual string BirthY { get; set; }
        public virtual string BirthM { get; set; }
        public virtual string BirthD { get; set; }
        public virtual string TEL { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string QQ { get; set; }
        public virtual string MSN { get; set; }
        public virtual string City1 { get; set; }
        public virtual string City2 { get; set; }
        public virtual string Post { get; set; }
        public virtual string Address { get; set; }
        public virtual string SafeId { get; set; }
        public virtual string BodyID2 { get; set; }
    }

    /// <summary>
    /// A class which represents the LogAction table.
    /// </summary>
	[Table("LogAction")]
    public partial class LogAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ActionNum { get; set; }
        public virtual int ChaNum { get; set; }
        public virtual int Type { get; set; }
        public virtual int TargetNum { get; set; }
        public virtual int TargetType { get; set; }
        public virtual int BrightPoint { get; set; }
        public virtual int LifePoint { get; set; }
        public virtual decimal ExpPoint { get; set; }
        public virtual decimal ActionMoney { get; set; }
        public virtual DateTime ActionDate { get; set; }
    }

    /// <summary>
    /// A class which represents the item table.
    /// </summary>
	[Table("item")]
    public partial class item
    {
        public virtual string ItemID { get; set; }
        public virtual string ItemMain { get; set; }
        public virtual string ItemSub { get; set; }
        public virtual string ItemName { get; set; }
        public virtual string ItemDescription { get; set; }
        public virtual string ItemImage { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long ItemNum { get; set; }
    }

    /// <summary>
    /// A class which represents the Vote table.
    /// </summary>
	[Table("Vote")]
    public partial class Vote
    {
        public virtual string UserName { get; set; }
        public virtual string votetime { get; set; }
        public virtual int? link { get; set; }
    }

    /// <summary>
    /// A class which represents the Web_links table.
    /// </summary>
	[Table("Web_links")]
    public partial class Weblink
    {
        public virtual string link_name { get; set; }
        public virtual string link_address { get; set; }
        public virtual string link_description { get; set; }
        public virtual string link_id { get; set; }
        public virtual string link_date { get; set; }
    }

    /// <summary>
    /// A class which represents the gmc table.
    /// </summary>
	[Table("gmc")]
    public partial class gmc
    {
        public virtual string username { get; set; }
        public virtual string session { get; set; }
        public virtual string sesexp { get; set; }
    }

    /// <summary>
    /// A class which represents the LogGameTime table.
    /// </summary>
	[Table("LogGameTime")]
    public partial class LogGameTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long GameTimeNum { get; set; }
        public virtual DateTime LogDate { get; set; }
        public virtual int GameTime { get; set; }
        public virtual string UserID { get; set; }
        public virtual int? UserNum { get; set; }
        public virtual int? SGNum { get; set; }
        public virtual int? SvrNum { get; set; }
        public virtual int? ChaNum { get; set; }
    }

    /// <summary>
    /// A class which represents the TB_CC_IP table.
    /// </summary>
	[Table("TB_CC_IP")]
    public partial class TBCCIP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int IpNum { get; set; }
        public virtual string CC_Class { get; set; }
        public virtual string CC_IP { get; set; }
        public virtual string Username { get; set; }
        public virtual string IcafeCode { get; set; }
        public virtual DateTime? REG_DATE { get; set; }
    }

    /// <summary>
    /// A class which represents the UserInfo table.
    /// </summary>
	[Table("UserInfo")]
    public partial class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int UserNum { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserID { get; set; }
        public virtual string UserPass { get; set; }
        public virtual string UserPass2 { get; set; }
        public virtual int UserType { get; set; }
        public virtual int UserLoginState { get; set; }
        public virtual int? UserAvailable { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime LastLoginDate { get; set; }
        public virtual int? SGNum { get; set; }
        public virtual int? SvrNum { get; set; }
        public virtual string ChaName { get; set; }
        public virtual int UserBlock { get; set; }
        public virtual DateTime UserBlockDate { get; set; }
        public virtual int ChaRemain { get; set; }
        public virtual int ChaTestRemain { get; set; }
        public virtual DateTime PremiumDate { get; set; }
        public virtual DateTime ChatBlockDate { get; set; }
        public virtual string UserEmail { get; set; }
        public virtual int? UserPoint { get; set; }
        public virtual string Upass { get; set; }
        public virtual string IpSite { get; set; }
        public virtual string Donated { get; set; }
        public virtual string WebLoginState { get; set; }
        public virtual int? last_vote1 { get; set; }
        public virtual int? last_vote2 { get; set; }
        public virtual int? last_vote3 { get; set; }
        public virtual int? last_vote4 { get; set; }
        public virtual int? last_vote5 { get; set; }
        public virtual int? last_vote6 { get; set; }
        public virtual DateTime? date { get; set; }
        public virtual int? UserAge { get; set; }
        public virtual DateTime OfflineTime { get; set; }
        public virtual DateTime GameTime { get; set; }
        public virtual int? last_vote7 { get; set; }
        public virtual int? last_vote8 { get; set; }
        public virtual int? last_vote9 { get; set; }
        public virtual int? last_vote10 { get; set; }
        public virtual string UserIP { get; set; }
        public virtual DateTime? UserLastLoginDate { get; set; }
        public virtual int VoteCounts { get; set; }
        public virtual decimal VipPoints { get; set; }
        public virtual int VipMem { get; set; }
        public virtual string UserPass1 { get; set; }
        public virtual string VipExpire { get; set; }
        public virtual int? GameTime2 { get; set; }
        public virtual int Gametime3 { get; set; }
        public virtual string MainCharacter { get; set; }
        public virtual int AHLoginState { get; set; }
        public virtual int? UserPoint2 { get; set; }
        public virtual string NewUserPass { get; set; }
        public virtual string NewUserPass2 { get; set; }
        public virtual string Activation_Code { get; set; }
        public virtual int? Activation_State { get; set; }
        public virtual string UserSQ { get; set; }
        public virtual string UserSA { get; set; }
        public virtual int? GameTime1 { get; set; }
        public virtual int? ClubWarRewards { get; set; }
        public virtual string IPBonus { get; set; }
        public virtual string LogIPAddress { get; set; }
        public virtual int bNewRegister { get; set; }
        public virtual int totalGameTime { get; set; }
    }

    /// <summary>
    /// A class which represents the LogGmCmd table.
    /// </summary>
	[Table("LogGmCmd")]
    public partial class LogGmCmd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int GmCmdNum { get; set; }
        public virtual DateTime? LogDate { get; set; }
        public virtual string GmCmd { get; set; }
        public virtual int? UserNum { get; set; }
    }

    /// <summary>
    /// A class which represents the LogLogin table.
    /// </summary>
	[Table("LogLogin")]
    public partial class LogLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long LoginNum { get; set; }
        public virtual int UserNum { get; set; }
        public virtual string UserID { get; set; }
        public virtual int LogInOut { get; set; }
        public virtual DateTime? LogDate { get; set; }
        public virtual string LogIpAddress { get; set; }
    }

    /// <summary>
    /// A class which represents the LogServerState table.
    /// </summary>
	[Table("LogServerState")]
    public partial class LogServerState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int SvrStateNum { get; set; }
        public virtual DateTime LogDate { get; set; }
        public virtual int UserNum { get; set; }
        public virtual int UserMaxNum { get; set; }
        public virtual int SvrNum { get; set; }
        public virtual int SGNum { get; set; }
    }

    /// <summary>
    /// A class which represents the newcheckid table.
    /// </summary>
	[Table("newcheckid")]
    public partial class newcheckid
    {
        public virtual string Id { get; set; }
        public virtual DateTime? CreateDate { get; set; }
    }

    /// <summary>
    /// A class which represents the rvslot table.
    /// </summary>
	[Table("rvslot")]
    public partial class rvslot
    {
        public virtual int? id { get; set; }
        public virtual string _rvslot { get; set; }
        public virtual string hex { get; set; }
        public virtual string hexnum { get; set; }
    }

    /// <summary>
    /// A class which represents the ServerGroup table.
    /// </summary>
	[Table("ServerGroup")]
    public partial class ServerGroup
    {
        [Key]
        public virtual int SGNum { get; set; }
        public virtual string SGName { get; set; }
        public virtual string OdbcName { get; set; }
        public virtual string OdbcUserID { get; set; }
        public virtual string OdbcPassword { get; set; }
        public virtual string OdbcLogName { get; set; }
        public virtual string OdbcLogUserID { get; set; }
        public virtual string OdbcLogPassword { get; set; }
    }

    /// <summary>
    /// A class which represents the ServerInfo table.
    /// </summary>
	[Table("ServerInfo")]
    public partial class ServerInfo
    {
        [Key]
        public virtual int SGNum { get; set; }
        [Key]
        public virtual int SvrNum { get; set; }
        public virtual int SvrType { get; set; }
    }

    /// <summary>
    /// A class which represents the skill table.
    /// </summary>
	[Table("skill")]
    public partial class skill
    {
        public virtual string SDN { get; set; }
        public virtual string SkillMain { get; set; }
        public virtual string SkillSub { get; set; }
        public virtual string SkillName { get; set; }
        public virtual string SkillImage { get; set; }
        public virtual string SkillDescription { get; set; }
        public virtual int? SkillType { get; set; }
        public virtual int? SkillStyle { get; set; }
    }

    /// <summary>
    /// A class which represents the Skills table.
    /// </summary>
	[Table("Skills")]
    public partial class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int SkillNum { get; set; }
        public virtual string SkillMain { get; set; }
        public virtual string SkillSub { get; set; }
        public virtual string SkillName { get; set; }
        public virtual string SkillImage { get; set; }
        public virtual string SkillDescription { get; set; }
        public virtual int? SkillType { get; set; }
        public virtual int? SkillChar { get; set; }
        public virtual int SkillCost { get; set; }
        public virtual string SkillKey { get; set; }
        public virtual string SkillReq { get; set; }
        public virtual int? SkillLevel { get; set; }
        public virtual int? SkillGender { get; set; }
    }

    /// <summary>
    /// A class which represents the LogTopUp table.
    /// </summary>
	[Table("LogTopUp")]
    public partial class LogTopUp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
        public virtual string Code { get; set; }
        public virtual string Pin { get; set; }
        public virtual int? Value { get; set; }
        public virtual DateTime? DateUsed { get; set; }
        public virtual string UserName { get; set; }
    }

    /// <summary>
    /// A class which represents the SqlInjectionLog table.
    /// </summary>
	[Table("SqlInjectionLog")]
    public partial class SqlInjectionLog
    {
        public virtual string LastDate { get; set; }
        public virtual string SqlInject { get; set; }
        public virtual string HostIp { get; set; }
    }

    /// <summary>
    /// A class which represents the StatGameTime table.
    /// </summary>
	[Table("StatGameTime")]
    public partial class StatGameTime
    {
        [Key]
        public virtual int GYear { get; set; }
        [Key]
        public virtual int GMonth { get; set; }
        [Key]
        public virtual int GDay { get; set; }
        public virtual int? GTime { get; set; }
    }

    /// <summary>
    /// A class which represents the TopUp table.
    /// </summary>
	[Table("TopUp")]
    public partial class TopUp
    {
        public virtual string Code { get; set; }
        public virtual int CodeValue { get; set; }
        public virtual int bUsed { get; set; }
        public virtual string Pin { get; set; }
        public virtual DateTime? dateGen { get; set; }
    }

    /// <summary>
    /// A class which represents the StatLogin table.
    /// </summary>
	[Table("StatLogin")]
    public partial class StatLogin
    {
        [Key]
        public virtual int LYear { get; set; }
        [Key]
        public virtual int LMonth { get; set; }
        [Key]
        public virtual int LDay { get; set; }
        [Key]
        public virtual int LHour { get; set; }
        public virtual int? LCount { get; set; }
    }

    /// <summary>
    /// A class which represents the Web table.
    /// </summary>
	[Table("Web")]
    public partial class Web
    {
        public virtual string webtitle { get; set; }
        public virtual string resetmoney { get; set; }
        public virtual string pkmoney { get; set; }
        public virtual string resetlevel { get; set; }
        public virtual string servername { get; set; }
        public virtual string client { get; set; }
        public virtual string patch { get; set; }
        public virtual string launcher { get; set; }
        public virtual string serverwebsite { get; set; }
        public virtual string resetpoints { get; set; }
        public virtual string resetslimit { get; set; }
        public virtual string resetmode { get; set; }
        public virtual string levelupmode { get; set; }
        public virtual string announcements { get; set; }
        public virtual string forum { get; set; }
        public virtual string ads { get; set; }
        public virtual string clean_inventory { get; set; }
        public virtual string clean_skills { get; set; }
        public virtual string store_inbox { get; set; }
        public virtual string store_sent { get; set; }
        public virtual string msg_length { get; set; }
        public virtual string md5 { get; set; }
        public virtual string show_gm { get; set; }
        public virtual string template { get; set; }
        public virtual string warp_zen { get; set; }
        public virtual string music { get; set; }
        public virtual string header { get; set; }
        public virtual string reset_stat { get; set; }
        public virtual string reset_skill { get; set; }
        public virtual string reset_quest { get; set; }
    }

    /// <summary>
    /// A class which represents the viewServerList view.
    /// </summary>
	[Table("viewServerList")]
    public partial class viewServerList
    {
        public virtual int SGNum { get; set; }
        public virtual int SvrNum { get; set; }
        public virtual int SvrType { get; set; }
        public virtual string SGName { get; set; }
        public virtual string OdbcName { get; set; }
        public virtual string OdbcUserID { get; set; }
        public virtual string OdbcPassword { get; set; }
        public virtual string OdbcLogName { get; set; }
        public virtual string OdbcLogUserID { get; set; }
        public virtual string OdbcLogPassword { get; set; }
    }

    /// <summary>
    /// A class which represents the LogGTConv table.
    /// </summary>
	[Table("LogGTConv")]
    public partial class LogGTConv
    {
        public virtual int ID { get; set; }
        public virtual string UserID { get; set; }
        public virtual int? AfterGT { get; set; }
        public virtual int? NewGT { get; set; }
        public virtual DateTime? ConvDate { get; set; }
        public virtual int? AfterBP { get; set; }
        public virtual int? NewBP { get; set; }
    }

    /// <summary>
    /// A class which represents the Web_admin table.
    /// </summary>
	[Table("Web_admin")]
    public partial class Webadmin
    {
        public virtual string username { get; set; }
        public virtual string password { get; set; }
        public virtual string securitycode { get; set; }
    }

    /// <summary>
    /// A class which represents the viewLogGameTime view.
    /// </summary>
	[Table("viewLogGameTime")]
    public partial class viewLogGameTime
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long GameTimeNum { get; set; }
        public virtual DateTime LogDate { get; set; }
        public virtual int GameTime { get; set; }
        public virtual string UserID { get; set; }
        public virtual int? UserNum { get; set; }
        public virtual int? SGNum { get; set; }
        public virtual int? SvrNum { get; set; }
        public virtual int? ChaNum { get; set; }
    }

    /// <summary>
    /// A class which represents the viewLogLogin view.
    /// </summary>
	[Table("viewLogLogin")]
    public partial class viewLogLogin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long LoginNum { get; set; }
        public virtual int UserNum { get; set; }
        public virtual string UserID { get; set; }
        public virtual int LogInOut { get; set; }
        public virtual DateTime? LogDate { get; set; }
        public virtual string LogIpAddress { get; set; }
    }

    /// <summary>
    /// A class which represents the Web_mail table.
    /// </summary>
	[Table("Web_mail")]
    public partial class Webmail
    {
        public virtual string to_character { get; set; }
        public virtual string from_character { get; set; }
        public virtual string accountid { get; set; }
        public virtual string subject { get; set; }
        public virtual string mail_msg { get; set; }
        public virtual string inbox { get; set; }
        public virtual string sent { get; set; }
        public virtual string read_msg { get; set; }
        public virtual string date { get; set; }
    }

    /// <summary>
    /// A class which represents the Web_servers table.
    /// </summary>
	[Table("Web_servers")]
    public partial class Webserver
    {
        public virtual string name { get; set; }
        public virtual string experience { get; set; }
        public virtual string drops { get; set; }
        public virtual string gsport { get; set; }
        public virtual string ip { get; set; }
        public virtual string display_order { get; set; }
        public virtual string version { get; set; }
        public virtual string type { get; set; }
    }


    /// <summary>
    /// A class which represents the Web_mail_store table.
    /// </summary>
	[Table("Web_mail_store")]
    public partial class Webmailstore
    {
        public virtual string accountid { get; set; }
        public virtual string store_inbox { get; set; }
        public virtual string store_sent { get; set; }
    }
}
