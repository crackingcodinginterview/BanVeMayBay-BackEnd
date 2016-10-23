namespace BanVeMayBay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAirroute : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AirrouteAirports", "Airroute_Id", "dbo.Airroutes");
            DropForeignKey("dbo.AirrouteAirports", "Airport_Id", "dbo.Airports");
            DropIndex("dbo.AirrouteAirports", new[] { "Airroute_Id" });
            DropIndex("dbo.AirrouteAirports", new[] { "Airport_Id" });
            DropTable("dbo.Airroutes");
            DropTable("dbo.AirrouteAirports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AirrouteAirports",
                c => new
                    {
                        Airroute_Id = c.String(nullable: false, maxLength: 128),
                        Airport_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Airroute_Id, t.Airport_Id });
            
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
            
            CreateIndex("dbo.AirrouteAirports", "Airport_Id");
            CreateIndex("dbo.AirrouteAirports", "Airroute_Id");
            AddForeignKey("dbo.AirrouteAirports", "Airport_Id", "dbo.Airports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AirrouteAirports", "Airroute_Id", "dbo.Airroutes", "Id", cascadeDelete: true);
        }
    }
}
