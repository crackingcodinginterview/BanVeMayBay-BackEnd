namespace BanVeMayBay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReservationticketModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservationtickets", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservationtickets", "Price");
        }
    }
}
