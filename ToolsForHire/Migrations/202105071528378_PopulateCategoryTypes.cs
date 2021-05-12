namespace ToolsForHire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CategoryTypes (Id, Name) VALUES (1, 'Heavy')");
            Sql("INSERT INTO CategoryTypes (Id, Name) VALUES (2, 'OneHand')");
            Sql("INSERT INTO CategoryTypes (Id, Name) VALUES (3, 'TwoMan')");
        }
        
        public override void Down()
        {
        }
    }
}
