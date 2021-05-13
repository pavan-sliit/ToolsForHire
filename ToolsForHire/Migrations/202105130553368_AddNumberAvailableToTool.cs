namespace ToolsForHire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToTool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tools", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Tools SET NumberAvailable = NoInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tools", "NumberAvailable");
        }
    }
}
