namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerHeightAndWeightChangeToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "Height", c => c.Int(nullable: false));
            AlterColumn("dbo.Players", "Weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Players", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
