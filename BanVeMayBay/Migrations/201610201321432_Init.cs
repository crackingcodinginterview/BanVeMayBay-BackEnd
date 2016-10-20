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
                        FromAirportId = c.String(maxLength: 128),
                        ToAirportId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Airport_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airports", t => t.FromAirportId)
                .ForeignKey("dbo.Airports", t => t.ToAirportId)
                .ForeignKey("dbo.Airports", t => t.Airport_Id)
                .Index(t => t.FromAirportId)
                .Index(t => t.ToAirportId)
                .Index(t => t.Airport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Airroutes", "Airport_Id", "dbo.Airports");
            DropForeignKey("dbo.Airroutes", "ToAirportId", "dbo.Airports");
            DropForeignKey("dbo.Airroutes", "FromAirportId", "dbo.Airports");
            DropIndex("dbo.Airroutes", new[] { "Airport_Id" });
            DropIndex("dbo.Airroutes", new[] { "ToAirportId" });
            DropIndex("dbo.Airroutes", new[] { "FromAirportId" });
            DropTable("dbo.Airroutes");
            DropTable("dbo.Airports");
        }
    }
}
