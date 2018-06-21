namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateUsesOfBuilding : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UsesOfBuilding (Id,usedFor) VALUES(1,'residential')");
            Sql("INSERT INTO UsesOfBuilding (Id,usedFor) VALUES(2,'institution')");
            Sql("INSERT INTO UsesOfBuilding (Id,usedFor) VALUES(3,'residential')");
            Sql("INSERT INTO UsesOfBuilding (Id,usedFor) VALUES(4,'residential')");
        }
        
        public override void Down()
        {
        }
    }
}
