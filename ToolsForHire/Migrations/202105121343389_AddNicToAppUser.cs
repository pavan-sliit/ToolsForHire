namespace ToolsForHire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNicToAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NicNumber", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NicNumber");
        }
    }
}
