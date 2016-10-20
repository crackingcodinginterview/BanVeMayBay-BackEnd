namespace BanVeMayBay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Airroutes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AirrouteAirports",
                c => new
                    {
                        Airroute_Id = c.String(nullable: false, maxLength: 128),
                        Airport_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Airroute_Id, t.Airport_Id })
                .ForeignKey("dbo.Airroutes", t => t.Airroute_Id, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.Airport_Id, cascadeDelete: true)
                .Index(t => t.Airroute_Id)
                .Index(t => t.Airport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AirrouteAirports", "Airport_Id", "dbo.Airports");
            DropForeignKey("dbo.AirrouteAirports", "Airroute_Id", "dbo.Airroutes");
            DropIndex("dbo.AirrouteAirports", new[] { "Airport_Id" });
            DropIndex("dbo.AirrouteAirports", new[] { "Airroute_Id" });
            DropTable("dbo.AirrouteAirports");
            DropTable("dbo.Airroutes");
            DropTable("dbo.Airports");
        }
    }
}
