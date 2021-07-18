namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUsers : DbMigration
    {
        public override void Up()
        {
            
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c796158e-8940-4eb8-b2fd-1ba4d67b3096', N'admin@admin.com', 0, N'AKyBqgkiDyrcZwDj43modr8LpoWpF2+veJl4d4is31z/cu0NPb7hsKt7AIdpj0b4vA==', N'1a800891-2eeb-4c0a-ba63-00422ea75fde', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'85d0bc25-c040-4e77-8545-6d0b6a014bd9', N'Admin')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c796158e-8940-4eb8-b2fd-1ba4d67b3096', N'85d0bc25-c040-4e77-8545-6d0b6a014bd9')");
            
        }
        
        public override void Down()
        {
        }
    }
}
