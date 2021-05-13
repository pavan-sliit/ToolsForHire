namespace ToolsForHire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentals : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Tool_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tools", t => t.Tool_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Tool_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Tool_Id", "dbo.Tools");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Tool_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
