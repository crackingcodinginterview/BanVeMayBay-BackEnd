namespace BanVeMayBay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservationtickets", "Ticketclass_Id", "dbo.Ticketclasses");
            DropIndex("dbo.Reservationtickets", new[] { "Ticketclass_Id" });
            AddColumn("dbo.Reservationtickets", "Ticketclass", c => c.Int(nullable: false));
            AlterColumn("dbo.Airports", "Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Flights", "Code", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Reservationtickets", "Code", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Customers", "IdentityCode", c => c.String(nullable: false));
            DropColumn("dbo.Reservationtickets", "Ticketclass_Id");
            DropTable("dbo.Ticketclasses");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Reservationtickets", "Ticketclass_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "IdentityCode", c => c.String());
            AlterColumn("dbo.Reservationtickets", "Code", c => c.String());
            AlterColumn("dbo.Flights", "Code", c => c.String());
            AlterColumn("dbo.Airports", "Code", c => c.String());
            DropColumn("dbo.Reservationtickets", "Ticketclass");
            CreateIndex("dbo.Reservationtickets", "Ticketclass_Id");
            AddForeignKey("dbo.Reservationtickets", "Ticketclass_Id", "dbo.Ticketclasses", "Id");
        }
    }
}
