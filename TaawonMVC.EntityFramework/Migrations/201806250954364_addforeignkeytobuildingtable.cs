namespace TaawonMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addforeignkeytobuildingtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buildings", "usesOfBuildingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Buildings", "usesOfBuildingID");
            AddForeignKey("dbo.Buildings", "usesOfBuildingID", "dbo.UsesOfBuildings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buildings", "usesOfBuildingID", "dbo.UsesOfBuildings");
            DropIndex("dbo.Buildings", new[] { "usesOfBuildingID" });
            DropColumn("dbo.Buildings", "usesOfBuildingID");
        }
    }
}
