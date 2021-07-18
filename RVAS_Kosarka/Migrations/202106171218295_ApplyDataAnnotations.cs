namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Stadium", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Games", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Players", "Name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Clubs", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Clubs", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Managers", "Name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.Positions", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Positions", "Name", c => c.String());
            AlterColumn("dbo.Managers", "Name", c => c.String());
            AlterColumn("dbo.Clubs", "City", c => c.String());
            AlterColumn("dbo.Clubs", "Name", c => c.String());
            AlterColumn("dbo.Players", "Name", c => c.String());
            AlterColumn("dbo.Games", "City", c => c.String());
            AlterColumn("dbo.Games", "Stadium", c => c.String());
        }
    }
}
