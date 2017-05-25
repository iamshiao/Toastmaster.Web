namespace Toastmaster.Web.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Beta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClubMember",
                c => new
                    {
                        ClubId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClubId, t.MemberId })
                .ForeignKey("dbo.Club", t => t.ClubId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.ClubId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Abbr = c.String(maxLength: 23),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsrName = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        ClubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Club", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Seq = c.Int(nullable: false),
                        HoldDate = c.DateTime(nullable: false),
                        Theme = c.String(nullable: false, maxLength: 255),
                        ClubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Club", t => t.ClubId, cascadeDelete: true)
                .Index(t => t.ClubId);
            
            CreateTable(
                "dbo.RoleRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        MemberId = c.Int(nullable: false),
                        MeetingId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meeting", t => t.MeetingId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.MeetingId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        EngFirstName = c.String(nullable: false, maxLength: 63),
                        EngLastName = c.String(nullable: false, maxLength: 63),
                        Mail = c.String(nullable: false, maxLength: 1023),
                        PhoneNum = c.String(maxLength: 55),
                        IsActive = c.Boolean(nullable: false),
                        IsGuest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpeechRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Project = c.String(nullable: false, maxLength: 63),
                        ProjectSeq = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 127),
                        MemberId = c.Int(nullable: false),
                        MeetingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meeting", t => t.MeetingId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.MeetingId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Abbr = c.String(maxLength: 23),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberClub",
                c => new
                    {
                        Member_Id = c.Int(nullable: false),
                        Club_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_Id, t.Club_Id })
                .ForeignKey("dbo.Member", t => t.Member_Id, cascadeDelete: true)
                .ForeignKey("dbo.Club", t => t.Club_Id, cascadeDelete: true)
                .Index(t => t.Member_Id)
                .Index(t => t.Club_Id);
            
            CreateTable(
                "dbo.IERecord",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SpeechRecordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleRecord", t => t.Id)
                .ForeignKey("dbo.SpeechRecord", t => t.SpeechRecordId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.SpeechRecordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IERecord", "SpeechRecordId", "dbo.SpeechRecord");
            DropForeignKey("dbo.IERecord", "Id", "dbo.RoleRecord");
            DropForeignKey("dbo.ClubMember", "MemberId", "dbo.Member");
            DropForeignKey("dbo.ClubMember", "ClubId", "dbo.Club");
            DropForeignKey("dbo.RoleRecord", "RoleId", "dbo.Role");
            DropForeignKey("dbo.SpeechRecord", "MemberId", "dbo.Member");
            DropForeignKey("dbo.SpeechRecord", "MeetingId", "dbo.Meeting");
            DropForeignKey("dbo.RoleRecord", "MemberId", "dbo.Member");
            DropForeignKey("dbo.MemberClub", "Club_Id", "dbo.Club");
            DropForeignKey("dbo.MemberClub", "Member_Id", "dbo.Member");
            DropForeignKey("dbo.RoleRecord", "MeetingId", "dbo.Meeting");
            DropForeignKey("dbo.Meeting", "ClubId", "dbo.Club");
            DropForeignKey("dbo.Admin", "ClubId", "dbo.Club");
            DropIndex("dbo.IERecord", new[] { "SpeechRecordId" });
            DropIndex("dbo.IERecord", new[] { "Id" });
            DropIndex("dbo.MemberClub", new[] { "Club_Id" });
            DropIndex("dbo.MemberClub", new[] { "Member_Id" });
            DropIndex("dbo.SpeechRecord", new[] { "MeetingId" });
            DropIndex("dbo.SpeechRecord", new[] { "MemberId" });
            DropIndex("dbo.RoleRecord", new[] { "RoleId" });
            DropIndex("dbo.RoleRecord", new[] { "MeetingId" });
            DropIndex("dbo.RoleRecord", new[] { "MemberId" });
            DropIndex("dbo.Meeting", new[] { "ClubId" });
            DropIndex("dbo.Admin", new[] { "ClubId" });
            DropIndex("dbo.ClubMember", new[] { "MemberId" });
            DropIndex("dbo.ClubMember", new[] { "ClubId" });
            DropTable("dbo.IERecord");
            DropTable("dbo.MemberClub");
            DropTable("dbo.Role");
            DropTable("dbo.SpeechRecord");
            DropTable("dbo.Member");
            DropTable("dbo.RoleRecord");
            DropTable("dbo.Meeting");
            DropTable("dbo.Admin");
            DropTable("dbo.Club");
            DropTable("dbo.ClubMember");
        }
    }
}
