namespace Toastmaster.Web.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChineseAbbrToClub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Club", "ChineseAbbr", c => c.String(maxLength: 23));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Club", "ChineseAbbr");
        }
    }
}
