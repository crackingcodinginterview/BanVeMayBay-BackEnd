namespace BanVeMayBay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        Time = c.DateTime(nullable: false),
                        NumSeat1 = c.Int(nullable: false),
                        NumSeat2 = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservationtickets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                        BookDate = c.DateTime(nullable: false),
                        NumSeatBook = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Flight_Id = c.String(maxLength: 128),
                        Ticketclass_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.Flight_Id)
                .ForeignKey("dbo.Ticketclasses", t => t.Ticketclass_Id)
                .Index(t => t.Flight_Id)
                .Index(t => t.Ticketclass_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdentityCode = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservationtickets", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Ticketclasses",
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
                "dbo.FlightAirports",
                c => new
                    {
                        Flight_Id = c.String(nullable: false, maxLength: 128),
                        Airport_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Flight_Id, t.Airport_Id })
                .ForeignKey("dbo.Flights", t => t.Flight_Id, cascadeDelete: true)
                .ForeignKey("dbo.Airports", t => t.Airport_Id, cascadeDelete: true)
                .Index(t => t.Flight_Id)
                .Index(t => t.Airport_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservationtickets", "Ticketclass_Id", "dbo.Ticketclasses");
            DropForeignKey("dbo.Reservationtickets", "Flight_Id", "dbo.Flights");
            DropForeignKey("dbo.Customers", "Id", "dbo.Reservationtickets");
            DropForeignKey("dbo.FlightAirports", "Airport_Id", "dbo.Airports");
            DropForeignKey("dbo.FlightAirports", "Flight_Id", "dbo.Flights");
            DropIndex("dbo.FlightAirports", new[] { "Airport_Id" });
            DropIndex("dbo.FlightAirports", new[] { "Flight_Id" });
            DropIndex("dbo.Customers", new[] { "Id" });
            DropIndex("dbo.Reservationtickets", new[] { "Ticketclass_Id" });
            DropIndex("dbo.Reservationtickets", new[] { "Flight_Id" });
            DropTable("dbo.FlightAirports");
            DropTable("dbo.Ticketclasses");
            DropTable("dbo.Customers");
            DropTable("dbo.Reservationtickets");
            DropTable("dbo.Flights");
        }
    }
}
