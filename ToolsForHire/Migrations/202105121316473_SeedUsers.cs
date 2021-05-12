namespace ToolsForHire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4c6137a7-d7e8-4d55-81b2-e80c945e2bdf', N'admin@gmail.com', 0, N'ACUqzm5rgNIKXempB0wlZiX/njAXJ3z9nmXyNOYdIbJ7mjwOVAw0xRJVpngUPDT3XA==', N'b37a478b-91d6-4e9d-93f3-83837d694bd8', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8756dcdd-74d1-4fd8-9b83-fb9099ed301d', N'guest@gmail.com', 0, N'AOqhJbM+EVi9rDOXJSnpMEq1zN6JREKnQAWngKi+auSvdqjp2XWB5hSSygc+QKupTA==', N'aabe26d7-aeb0-458a-8d2a-7a528cd63620', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'75c2f9e3-997e-47c6-8c02-67d1a2cf5c9e', N'CanManageTools')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4c6137a7-d7e8-4d55-81b2-e80c945e2bdf', N'75c2f9e3-997e-47c6-8c02-67d1a2cf5c9e')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
