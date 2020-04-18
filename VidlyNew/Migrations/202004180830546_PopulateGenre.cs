namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres values(1,'Comedy')");
            Sql("Insert into Genres values(2,'Romantic')");
            Sql("Insert into Genres values(3,'Family')");
            Sql("Insert into Genres values(4,'Action')");
            Sql("Insert into Genres values(5,'Adventure')");
            Sql("Insert into Genres values(6,'SciFi')");
            Sql("Insert into Genres values(7,'Animation')");
        }
        
        public override void Down()
        {
        }
    }
}
