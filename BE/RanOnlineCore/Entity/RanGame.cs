namespace RanOnlineCore.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// A class which represents the ChaNameInfo table.
    /// </summary>
	[Table("ChaNameInfo")]
    public partial class ChaNameInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ChaNameNum { get; set; }
        public virtual int ChaNum { get; set; }
        public virtual string ChaName { get; set; }
    }

    /// <summary>
    /// A class which represents the VehicleInfo table.
    /// </summary>
	[Table("VehicleInfo")]
    public partial class VehicleInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int VehicleUniqueNum { get; set; }
        public virtual int VehicleNum { get; set; }
        public virtual string VehicleName { get; set; }
        public virtual int VehicleChaNum { get; set; }
        public virtual int VehicleType { get; set; }
        public virtual int VehicleCardMID { get; set; }
        public virtual int VehicleCardSID { get; set; }
        public virtual int VehicleBattery { get; set; }
        public virtual int VehicleDeleted { get; set; }
        public virtual DateTime VehicleCreateDate { get; set; }
        public virtual DateTime VehicleDeletedDate { get; set; }
        public virtual byte[] VehiclePutOnItems { get; set; }
        public virtual int VehicleColor { get; set; }
        public virtual int VehicleColor1 { get; set; }
        public virtual int VehicleColor2 { get; set; }
        public virtual int VehicleColor3 { get; set; }
        public virtual int VehicleColor4 { get; set; }
        public virtual int VehicleColor5 { get; set; }
    }

    /// <summary>
    /// A class which represents the ChaFriendBackup table.
    /// </summary>
	[Table("ChaFriendBackup")]
    public partial class ChaFriendBackup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ChaFriendNum { get; set; }
        public virtual int ChaP { get; set; }
        public virtual int ChaS { get; set; }
        public virtual int ChaFlag { get; set; }
    }

    /// <summary>
    /// A class which represents the PetInfo table.
    /// </summary>
	[Table("PetInfo")]
    public partial class PetInfo
    {
        public virtual int PetNum { get; set; }
        public virtual string PetName { get; set; }
        public virtual int PetChaNum { get; set; }
        public virtual int PetType { get; set; }
        public virtual int PetMID { get; set; }
        public virtual int PetSID { get; set; }
        public virtual int PetStyle { get; set; }
        public virtual int PetColor { get; set; }
        public virtual int PetFull { get; set; }
        public virtual int PetDeleted { get; set; }
        public virtual DateTime PetCreateDate { get; set; }
        public virtual DateTime PetDeletedDate { get; set; }
        public virtual byte[] PetPutOnItems { get; set; }
        public virtual int PetCardMID { get; set; }
        public virtual int PetCardSID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int PetUniqueNum { get; set; }
        public virtual DateTime? PetSkinStartDate { get; set; }
        public virtual DateTime? PetSkinTime { get; set; }
        public virtual int? PetSkinScale { get; set; }
        public virtual int? PetSkinSID { get; set; }
        public virtual int? PetSkinMID { get; set; }
        public virtual int? PetDualSkill { get; set; }
    }

    /// <summary>
    /// A class which represents the GuildAlliance table.
    /// </summary>
	[Table("GuildAlliance")]
    public partial class GuildAlliance
    {
        [Key]
        public virtual int GuNumP { get; set; }
        [Key]
        public virtual int GuNumS { get; set; }
    }

    /// <summary>
    /// A class which represents the GuildInfo table.
    /// </summary>
	[Table("GuildInfo")]
    public partial class GuildInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int GuNum { get; set; }
        public virtual int ChaNum { get; set; }
        public virtual int GuDeputy { get; set; }
        public virtual string GuName { get; set; }
        public virtual string GuNotice { get; set; }
        public virtual int GuRank { get; set; }
        public virtual decimal GuMoney { get; set; }
        public virtual decimal GuIncomeMoney { get; set; }
        public virtual int GuMarkVer { get; set; }
        public virtual int GuExpire { get; set; }
        public virtual DateTime GuMakeTime { get; set; }
        public virtual DateTime GuExpireTime { get; set; }
        public virtual DateTime GuAllianceSec { get; set; }
        public virtual DateTime GuAllianceDis { get; set; }
        public virtual byte[] GuMarkImage { get; set; }
        public virtual byte[] GuStorage { get; set; }
        public virtual DateTime GuAuthorityTime { get; set; }
        public virtual int GuAllianceBattleLose { get; set; }
        public virtual int GuAllianceBattleDraw { get; set; }
        public virtual int GuAllianceBattleWin { get; set; }
        public virtual DateTime GuBattleLastTime { get; set; }
        public virtual int GuBattleLose { get; set; }
        public virtual int GuBattleDraw { get; set; }
        public virtual int GuBattleWin { get; set; }
        public virtual int GuCWarSGPoints { get; set; }
        public virtual int GuCWarMPPoints { get; set; }
        public virtual int GuCWarPHXPoints { get; set; }
        public virtual int GuCWarTHPoints { get; set; }
    }

    /// <summary>
    /// A class which represents the ChaInfo table.
    /// </summary>
	[Table("ChaInfo")]
    public partial class ChaInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ChaNum { get; set; }
        public virtual int? SGNum { get; set; }
        public virtual int UserNum { get; set; }
        public virtual int? GuNum { get; set; }
        public virtual int GuPosition { get; set; }
        public virtual string ChaName { get; set; }
        public virtual string ChaGuName { get; set; }
        public virtual int ChaTribe { get; set; }
        public virtual int ChaClass { get; set; }
        public virtual int ChaSchool { get; set; }
        public virtual int ChaHair { get; set; }
        public virtual int ChaFace { get; set; }
        public virtual int ChaLiving { get; set; }
        public virtual int ChaLevel { get; set; }
        public virtual decimal ChaMoney { get; set; }
        public virtual long ChaPower { get; set; }
        public virtual long ChaStrong { get; set; }
        public virtual long ChaStrength { get; set; }
        public virtual long ChaSpirit { get; set; }
        public virtual long ChaDex { get; set; }
        public virtual long ChaIntel { get; set; }
        public virtual long ChaStRemain { get; set; }
        public virtual decimal ChaExp { get; set; }
        public virtual int ChaViewRange { get; set; }
        public virtual long ChaHP { get; set; }
        public virtual long ChaMP { get; set; }
        public virtual int ChaStartMap { get; set; }
        public virtual int ChaStartGate { get; set; }
        public virtual double ChaPosX { get; set; }
        public virtual double ChaPosY { get; set; }
        public virtual double ChaPosZ { get; set; }
        public virtual int ChaSaveMap { get; set; }
        public virtual double ChaSavePosX { get; set; }
        public virtual double ChaSavePosY { get; set; }
        public virtual double ChaSavePosZ { get; set; }
        public virtual int ChaReturnMap { get; set; }
        public virtual double ChaReturnPosX { get; set; }
        public virtual double ChaReturnPosY { get; set; }
        public virtual double ChaReturnPosZ { get; set; }
        public virtual int ChaBright { get; set; }
        public virtual int ChaAttackP { get; set; }
        public virtual int ChaDefenseP { get; set; }
        public virtual int ChaFightA { get; set; }
        public virtual int ChaShootA { get; set; }
        public virtual long ChaSP { get; set; }
        public virtual int ChaPK { get; set; }
        public virtual int ChaSkillPoint { get; set; }
        public virtual int ChaInvenLine { get; set; }
        public virtual int ChaDeleted { get; set; }
        public virtual int ChaOnline { get; set; }
        public virtual DateTime ChaCreateDate { get; set; }
        public virtual DateTime ChaDeletedDate { get; set; }
        public virtual DateTime ChaStorage2 { get; set; }
        public virtual DateTime ChaStorage3 { get; set; }
        public virtual DateTime ChaStorage4 { get; set; }
        public virtual DateTime ChaGuSecede { get; set; }
        public virtual byte[] ChaQuest { get; set; }
        public virtual byte[] ChaSkills { get; set; }
        public virtual byte[] ChaSkillSlot { get; set; }
        public virtual byte[] ChaActionSlot { get; set; }
        public virtual byte[] ChaPutOnItems { get; set; }
        public virtual byte[] ChaInven { get; set; }
        public virtual int ChaReborn { get; set; }
        public virtual int? ChaSex { get; set; }
        public virtual int? ChaHairStyle { get; set; }
        public virtual int? ChaHairColor { get; set; }
        public virtual double ChaReExp { get; set; }
        public virtual string FixInject { get; set; }
        public virtual string AuctionTimeOut { get; set; }
        public virtual DateTime? ChaRebornDate { get; set; }
        public virtual int? ChaSpecial { get; set; }
        public virtual int? ChaKill { get; set; }
        public virtual int? ChaRebornReset { get; set; }
        public virtual int? ChangeClass { get; set; }
        public virtual byte[] ChaCoolTime { get; set; }
        public virtual int? ChaSpSID { get; set; }
        public virtual int? ChaSpMID { get; set; }
        public virtual short? ChaF4Slot { get; set; }
        public virtual int LvlEvent { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual long ChaCP { get; set; }
        public virtual short? ChaF5Slot { get; set; }
        public virtual long? ChaDP { get; set; }
        public virtual long? ChaSerial { get; set; }
        public virtual long? ChaVote { get; set; }
        public virtual short? fix { get; set; }
        public virtual short ufix { get; set; }
        public virtual decimal? ChaPremiumPoint { get; set; }
        public virtual decimal? ChaVotePoint { get; set; }
        public virtual int? ChaPkLoss { get; set; }
        public virtual int? ChaPkWin { get; set; }
        public virtual long ChaAgility { get; set; }
        public virtual decimal? ChaClubWarVoteP { get; set; }
        public virtual decimal? ChaClubWarGoldP { get; set; }
        public virtual int? ChaClubWarRewards { get; set; }
        public virtual int ChaPremiumLevel { get; set; }
        public virtual int? ChaKills { get; set; }
        public virtual int ChaContribP { get; set; }
        public virtual int ChaBBP { get; set; }
        public virtual int ChaLevelWeb2 { get; set; }
        public virtual DateTime? LevelUpDate { get; set; }
        public virtual byte[] ChaLunchBox { get; set; }
        public virtual int? ChaActivityPoint { get; set; }
        public virtual byte[] ChaExtraActivity { get; set; }
    }

    /// <summary>
    /// A class which represents the ChaLastInfo table.
    /// </summary>
	[Table("ChaLastInfo")]
    public partial class ChaLastInfo
    {
        public virtual int ChaNum { get; set; }
        public virtual int ChaLevel { get; set; }
        public virtual decimal ChaMoney { get; set; }
    }

    /// <summary>
    /// A class which represents the GuildRegion table.
    /// </summary>
	[Table("GuildRegion")]
    public partial class GuildRegion
    {
        [Key]
        public virtual int RegionID { get; set; }
        [Key]
        public virtual int GuNum { get; set; }
        public virtual double RegionTax { get; set; }
    }

    /// <summary>
    /// A class which represents the PetInven table.
    /// </summary>
	[Table("PetInven")]
    public partial class PetInven
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int PetInvenNum { get; set; }
        public virtual int PetNum { get; set; }
        public virtual int PetInvenType { get; set; }
        public virtual int PetInvenMID { get; set; }
        public virtual int PetInvenSID { get; set; }
        public virtual int PetInvenCMID { get; set; }
        public virtual int PetInvenCSID { get; set; }
        public virtual int PetInvenAvailable { get; set; }
        public virtual DateTime PetInvenUpdateDate { get; set; }
        public virtual int PetChaNum { get; set; }
    }

    /// <summary>
    /// A class which represents the UserLastInfo table.
    /// </summary>
	[Table("UserLastInfo")]
    public partial class UserLastInfo
    {
        public virtual int UserNum { get; set; }
        public virtual decimal UserMoney { get; set; }
    }

    /// <summary>
    /// A class which represents the UserInven table.
    /// </summary>
	[Table("UserInven")]
    public partial class UserInven
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int UserInvenNum { get; set; }
        public virtual int UserNum { get; set; }
        public virtual int SGNum { get; set; }
        public virtual DateTime ChaStorage2 { get; set; }
        public virtual DateTime ChaStorage3 { get; set; }
        public virtual DateTime ChaStorage4 { get; set; }
        public virtual decimal UserMoney { get; set; }
        public virtual byte[] _UserInven { get; set; }
    }

    /// <summary>
    /// A class which represents the PetStyleFlag table.
    /// </summary>
	[Table("PetStyleFlag")]
    public partial class PetStyleFlag
    {
        [Key]
        public virtual int PetStyle { get; set; }
        public virtual string PetStyleName { get; set; }
    }

    /// <summary>
    /// A class which represents the PetTypeFlag table.
    /// </summary>
	[Table("PetTypeFlag")]
    public partial class PetTypeFlag
    {
        [Key]
        public virtual int PetType { get; set; }
        public virtual string PetName { get; set; }
    }

    /// <summary>
    /// A class which represents the SwRegion table.
    /// </summary>
	[Table("SwRegion")]
    public partial class SwRegion
    {
        public virtual int? SwNum { get; set; }
        public virtual int? SwID { get; set; }
        public virtual int? sp_add_sw_region { get; set; }
    }

    /// <summary>
    /// A class which represents the ChaFriend table.
    /// </summary>
	[Table("ChaFriend")]
    public partial class ChaFriend
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ChaFriendNum { get; set; }
        public virtual int ChaP { get; set; }
        public virtual int ChaS { get; set; }
        public virtual int ChaFlag { get; set; }
    }

    /// <summary>
    /// A class which represents the SkillTableRef table.
    /// </summary>
	[Table("SkillTableRef")]
    public partial class SkillTableRef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int SkillNo { get; set; }
        public virtual int MID { get; set; }
        public virtual int SID { get; set; }
        public virtual string SkillName { get; set; }
        public virtual string SkillDes { get; set; }
        public virtual int? SkillClass { get; set; }
        public virtual int? SkillLevelReq { get; set; }
        public virtual int? SkillDexReq { get; set; }
        public virtual int? SkillStrongReq { get; set; }
        public virtual int? SkillIntReq { get; set; }
    }

    /// <summary>
    /// A class which represents the viewGuildInfo view.
    /// </summary>
	[Table("viewGuildInfo")]
    public partial class viewGuildInfo
    {
        public virtual int GuNum { get; set; }
        public virtual int ChaNum { get; set; }
        public virtual int GuDeputy { get; set; }
        public virtual string ChaName { get; set; }
        public virtual string GuName { get; set; }
        public virtual string GuNotice { get; set; }
        public virtual int GuRank { get; set; }
        public virtual decimal GuMoney { get; set; }
        public virtual decimal GuIncomeMoney { get; set; }
        public virtual int GuMarkVer { get; set; }
        public virtual int GuExpire { get; set; }
        public virtual DateTime GuMakeTime { get; set; }
        public virtual DateTime GuExpireTime { get; set; }
        public virtual DateTime GuAllianceSec { get; set; }
        public virtual DateTime GuAllianceDis { get; set; }
        public virtual DateTime GuAuthorityTime { get; set; }
        public virtual int GuAllianceBattleLose { get; set; }
        public virtual int GuAllianceBattleDraw { get; set; }
        public virtual int GuAllianceBattleWin { get; set; }
        public virtual DateTime GuBattleLastTime { get; set; }
        public virtual int GuBattleLose { get; set; }
        public virtual int GuBattleDraw { get; set; }
        public virtual int GuBattleWin { get; set; }
        public virtual int? ChaSpMID { get; set; }
        public virtual int? ChaSpSID { get; set; }
    }

    /// <summary>
    /// A class which represents the Attendance table.
    /// </summary>
	[Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        public virtual int UserNum { get; set; }
        public virtual int? RewardCount { get; set; }
        public virtual int? DaysCount { get; set; }
        public virtual DateTime? AttendDate { get; set; }
    }

    /// <summary>
    /// A class which represents the GuildBattle table.
    /// </summary>
	[Table("GuildBattle")]
    public partial class GuildBattle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int GuBattleNum { get; set; }
        public virtual int? GuSNum { get; set; }
        public virtual int? GuPNum { get; set; }
        public virtual int? GuAlliance { get; set; }
        public virtual int? GuFlag { get; set; }
        public virtual int? GuKillNum { get; set; }
        public virtual int? GuDeathNum { get; set; }
        public virtual DateTime? GuBattleStartDate { get; set; }
        public virtual DateTime? GuBattleEndDate { get; set; }
    }

    /// <summary>
    /// A class which represents the ItemCustomize table.
    /// </summary>
	[Table("ItemCustomize")]
    public partial class ItemCustomize
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int GMID { get; set; }
        public virtual int MainID { get; set; }
        public virtual int SubID { get; set; }
        public virtual string ItemName { get; set; }
        public virtual bool ChangeQuantity { get; set; }
        public virtual bool AttackUpgrade { get; set; }
        public virtual bool DefenceUpgrade { get; set; }
        public virtual byte[] ChaInven { get; set; }
        public virtual long Point { get; set; }
        public virtual int AddDate { get; set; }
        public virtual string GmType { get; set; }
        public virtual bool EditBol { get; set; }
        public virtual string GfInfo { get; set; }
        public virtual string GmShuXing { get; set; }
        public virtual string GmPic { get; set; }
        public virtual bool AddBol { get; set; }
    }

    /// <summary>
    /// A class which represents the viewChaFriend view.
    /// </summary>
	[Table("viewChaFriend")]
    public partial class viewChaFriend
    {
        public virtual int ChaP { get; set; }
        public virtual int ChaS { get; set; }
        public virtual string ChaName { get; set; }
        public virtual int ChaFlag { get; set; }
    }

    /// <summary>
    /// A class which represents the viewGuildMember view.
    /// </summary>
	[Table("viewGuildMember")]
    public partial class viewGuildMember
    {
        public virtual int GuNum { get; set; }
        public virtual int ChaNum { get; set; }
        public virtual string ChaName { get; set; }
        public virtual string ChaGuName { get; set; }
        public virtual int GuPosition { get; set; }
    }
}
