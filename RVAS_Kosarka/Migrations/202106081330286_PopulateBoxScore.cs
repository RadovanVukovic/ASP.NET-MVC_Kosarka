namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBoxScore : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BoxScores VALUES( 4, 1 , 15, 4 , 8 )");
            Sql("INSERT INTO BoxScores VALUES( 4, 2 , 17, 6, 1)");
            Sql("INSERT INTO BoxScores VALUES( 5, 3 , 16,8,9)");
            Sql("INSERT INTO BoxScores VALUES( 5, 4 , 15,4,5)");
            Sql("INSERT INTO BoxScores VALUES( 6, 5 , 6,5,1)");
            Sql("INSERT INTO BoxScores VALUES( 6, 6 , 8,10,5)");
            Sql("INSERT INTO BoxScores VALUES( 7, 7,  26, 6, 7)");
            Sql("INSERT INTO BoxScores VALUES( 7, 8,  30, 5, 8)");

        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.BoxScores");

        }
    }
}
