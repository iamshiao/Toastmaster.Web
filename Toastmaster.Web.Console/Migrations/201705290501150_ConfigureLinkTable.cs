namespace Toastmaster.Web.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureLinkTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MemberClub", name: "Member_Id", newName: "MemberId");
            RenameColumn(table: "dbo.MemberClub", name: "Club_Id", newName: "ClubId");
            RenameIndex(table: "dbo.MemberClub", name: "IX_Member_Id", newName: "IX_MemberId");
            RenameIndex(table: "dbo.MemberClub", name: "IX_Club_Id", newName: "IX_ClubId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MemberClub", name: "IX_ClubId", newName: "IX_Club_Id");
            RenameIndex(table: "dbo.MemberClub", name: "IX_MemberId", newName: "IX_Member_Id");
            RenameColumn(table: "dbo.MemberClub", name: "ClubId", newName: "Club_Id");
            RenameColumn(table: "dbo.MemberClub", name: "MemberId", newName: "Member_Id");
        }
    }
}
