namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesGameAndBoxScore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoxScores",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        Rebounds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.PlayerId })
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomePoints = c.Int(nullable: false),
                        AwayPoints = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Stadium = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoxScores", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.BoxScores", "GameId", "dbo.Games");
            DropIndex("dbo.BoxScores", new[] { "PlayerId" });
            DropIndex("dbo.BoxScores", new[] { "GameId" });
            DropTable("dbo.Games");
            DropTable("dbo.BoxScores");
        }
    }
}
