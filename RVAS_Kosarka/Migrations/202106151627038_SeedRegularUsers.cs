namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRegularUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'89484cbe-70d3-4210-919c-0a86c812bc39', N'user@regular.com', 0, N'AOSwome+SY7tcAZW3N5W6z9nl4/IGc5jNKZroXmsIi5O4dQpW/0t2k7aY0/xtYdFGQ==', N'2fb58cc0-2626-4a92-8aef-5d4d4bad3350', NULL, 0, 0, NULL, 1, 0, N'user@regular.com')
                ");

            Sql(@"

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0aef9baf-0407-4314-a688-8cdf258601ea', N'RegularUser')
    
                ");

            Sql(@"
            INSERT INTO[dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES(N'89484cbe-70d3-4210-919c-0a86c812bc39', N'0aef9baf-0407-4314-a688-8cdf258601ea')
                ");
        }

        public override void Down()
        {
        }
    }
}
