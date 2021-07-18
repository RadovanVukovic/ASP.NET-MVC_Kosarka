namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateClubs : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Clubs VALUES( 'Celtics', 1938, 'Boston' )");
            Sql("INSERT INTO Clubs VALUES( 'Nets', 1940, 'Brooklyn' )");
            Sql("INSERT INTO Clubs VALUES( 'Mavericks', 1944, 'Dallas' )");
            Sql("INSERT INTO Clubs VALUES( 'Nugets', 1935, 'Denver' )");
            Sql("INSERT INTO Clubs VALUES( 'Lakers', 1938, 'Los Angeles' )");
            Sql("INSERT INTO Clubs VALUES( 'Atlanta', 1937, 'Hawks' )");
            Sql("INSERT INTO Clubs VALUES( 'Clippers', 1942, 'Los Angeles' )");
            Sql("INSERT INTO Clubs VALUES( 'Grizzlies', 1935, 'Memphis' )");
            Sql("INSERT INTO Clubs VALUES( 'Heat', 1945, 'Miami ' )");
            Sql("INSERT INTO Clubs VALUES( 'Knicks', 1933, 'New York' )");

        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.Clubs");

        }
    }
}
