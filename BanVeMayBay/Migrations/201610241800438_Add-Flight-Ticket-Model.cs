namespace BanVeMayBay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFlightTicketModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flighttickets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Code = c.String(nullable: false, maxLength: 6),
                        Price = c.Int(nullable: false),
                        NumSeatAvailable = c.Int(nullable: false),
                        Ticketclass = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Flight_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.Flight_Id)
                .Index(t => t.Flight_Id);
            
            AddColumn("dbo.Customers", "Flightticket_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "Flightticket_Id");
            AddForeignKey("dbo.Customers", "Flightticket_Id", "dbo.Flighttickets", "Id");
            DropColumn("dbo.Reservationtickets", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservationtickets", "Price", c => c.Int(nullable: false));
            DropForeignKey("dbo.Flighttickets", "Flight_Id", "dbo.Flights");
            DropForeignKey("dbo.Customers", "Flightticket_Id", "dbo.Flighttickets");
            DropIndex("dbo.Customers", new[] { "Flightticket_Id" });
            DropIndex("dbo.Flighttickets", new[] { "Flight_Id" });
            DropColumn("dbo.Customers", "Flightticket_Id");
            DropTable("dbo.Flighttickets");
        }
    }
}
