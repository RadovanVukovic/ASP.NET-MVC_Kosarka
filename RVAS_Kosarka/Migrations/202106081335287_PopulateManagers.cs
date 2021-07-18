namespace RVAS_Kosarka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateManagers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Managers VALUES(1 , 'James Bosh ', 35)");
            Sql("INSERT INTO Managers VALUES(2,'Frank Barboza ', 28)");
            Sql("INSERT INTO Managers VALUES(3,'Antony Mark', 40)");
            Sql("INSERT INTO Managers VALUES(4,'Steve Kerr ', 42)");
            Sql("INSERT INTO Managers VALUES(5,'Pablo Gonzales ', 38)");
            Sql("INSERT INTO Managers VALUES(6,'Mark Piterson ', 26)");
            Sql("INSERT INTO Managers VALUES(7,'Kevin Jackman ', 39)");
            Sql("INSERT INTO Managers VALUES(8,'Hugh Wallace ', 37)");
            Sql("INSERT INTO Managers VALUES(9,'Marco Pelegrini ', 45)");
            Sql("INSERT INTO Managers VALUES(10,'John Klebert ', 46)");

        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE dbo.Managers");

        }
    }
}
