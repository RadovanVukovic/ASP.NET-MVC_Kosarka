namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGames : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games VALUES( 104 , 103 , '20200618 20:00:00' , ' TD Garden' ,  'Boston ')");
            Sql("INSERT INTO Games VALUES( 106 , 99 , '20200615 20:00:00' , 'Barclays Center ' ,  'Brooklyn ')");
            Sql("INSERT INTO Games VALUES( 84 , 95 , '20200613 20:00:00' , 'American Airlines Center ' ,  'Dallas ')");
            Sql("INSERT INTO Games VALUES( 96 , 112 , '20200610 20:00:00' , 'Ball Arena ' ,  'Denver ')");
            Sql("INSERT INTO Games VALUES( 115 , 110 , '20200608 20:00:00' , 'Staples Center ' ,  'Los Angeles ')");


        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.Games");

        }
    }
}
