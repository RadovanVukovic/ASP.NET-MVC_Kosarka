namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableClub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Founded = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            
            AddColumn("dbo.Players", "ClubId", c => c.Int(nullable: false));                     
            CreateIndex("dbo.Players", "ClubId");
            AddForeignKey("dbo.Players", "ClubId", "dbo.Clubs", "Id", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Players", "ClubId", "dbo.Clubs");
            DropIndex("dbo.Players", new[] { "ClubId" });
            
            DropColumn("dbo.Players", "ClubId");
            
            DropTable("dbo.Clubs");
        }
    }
}
