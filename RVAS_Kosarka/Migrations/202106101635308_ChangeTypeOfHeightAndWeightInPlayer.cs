namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeOfHeightAndWeightInPlayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Height", c => c.Double(nullable: false));
            AlterColumn("dbo.Players", "Weight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Weight", c => c.Single(nullable: false));
            AlterColumn("dbo.Players", "Height", c => c.Single(nullable: false));
        }
    }
}
