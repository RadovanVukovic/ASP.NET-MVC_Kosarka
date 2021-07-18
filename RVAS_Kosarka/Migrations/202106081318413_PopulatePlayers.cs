namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePlayers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Players VALUES( 'Bogdan Bogdanovic', 2.05, 85.6, 25, 2, 1 )");
            Sql("INSERT INTO Players VALUES( 'Nemanja Bjelica', 2.08, 88, 28, 4, 1 )");

            Sql("INSERT INTO Players VALUES( 'LeBron James', 2.09, 90, 33, 3, 2 )");
            Sql("INSERT INTO Players VALUES( 'Anthony Davis', 2.11, 92, 28, 4, 2 )");

            Sql("INSERT INTO Players VALUES( 'Luka Doncic', 2.05, 84.2, 22, 2, 3 )");
            Sql("INSERT INTO Players VALUES( 'Goran Dragic', 1.98, 78, 28, 1, 3 )");

            Sql("INSERT INTO Players VALUES( 'James Harden', 2.02, 85, 26, 1, 4 )");
            Sql("INSERT INTO Players VALUES( 'Kyrie Irving', 1.93, 79, 27, 2, 4 )");


        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.Players");

        }
    }
}
