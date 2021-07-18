namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePosition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Players", "PositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "PositionId");
            AddForeignKey("dbo.Players", "PositionId", "dbo.Positions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropTable("dbo.Positions");
        }
    }
}
