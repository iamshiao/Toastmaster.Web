namespace Toastmaster.Web.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberClubBack : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Member", new[] { "Mail" });
            AddColumn("dbo.Member", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.MemberClub", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.MemberClub", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MemberClub", "ResumeDate", c => c.DateTime(nullable: false));
            Sql("UPDATE dbo.Member SET Email = Mail");
            CreateIndex("dbo.Member", "Email", unique: true);
            DropColumn("dbo.Member", "Mail");
            DropColumn("dbo.Member", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Member", "Mail", c => c.String(nullable: false, maxLength: 255));
            DropIndex("dbo.Member", new[] { "Email" });
            DropColumn("dbo.MemberClub", "ResumeDate");
            DropColumn("dbo.MemberClub", "RegisterDate");
            DropColumn("dbo.MemberClub", "IsActive");
            DropColumn("dbo.Member", "Email");
            CreateIndex("dbo.Member", "Mail", unique: true);
        }
    }
}
