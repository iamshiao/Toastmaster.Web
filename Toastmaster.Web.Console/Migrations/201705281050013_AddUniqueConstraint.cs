namespace Toastmaster.Web.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClubMember", "ClubId", "dbo.Club");
            DropForeignKey("dbo.ClubMember", "MemberId", "dbo.Member");
            DropIndex("dbo.ClubMember", new[] { "ClubId" });
            DropIndex("dbo.ClubMember", new[] { "MemberId" });
            AlterColumn("dbo.Member", "Mail", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Admin", "UsrName", unique: true);
            CreateIndex("dbo.Club", "Name", unique: true);
            CreateIndex("dbo.Member", "Mail", unique: true);
            CreateIndex("dbo.Role", "Name", unique: true);
            DropColumn("dbo.Member", "IsGuest");
            DropTable("dbo.ClubMember");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClubMember",
                c => new
                    {
                        ClubId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClubId, t.MemberId });
            
            AddColumn("dbo.Member", "IsGuest", c => c.Boolean(nullable: false));
            DropIndex("dbo.Role", new[] { "Name" });
            DropIndex("dbo.Member", new[] { "Mail" });
            DropIndex("dbo.Club", new[] { "Name" });
            DropIndex("dbo.Admin", new[] { "UsrName" });
            AlterColumn("dbo.Member", "Mail", c => c.String(nullable: false, maxLength: 1023));
            CreateIndex("dbo.ClubMember", "MemberId");
            CreateIndex("dbo.ClubMember", "ClubId");
            AddForeignKey("dbo.ClubMember", "MemberId", "dbo.Member", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClubMember", "ClubId", "dbo.Club", "Id", cascadeDelete: true);
        }
    }
}
