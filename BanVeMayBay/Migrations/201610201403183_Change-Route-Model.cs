namespace BanVeMayBay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRouteModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Airroutes", name: "FromAirportId", newName: "FromAirport_Id");
            RenameColumn(table: "dbo.Airroutes", name: "ToAirportId", newName: "ToAirport_Id");
            RenameIndex(table: "dbo.Airroutes", name: "IX_FromAirportId", newName: "IX_FromAirport_Id");
            RenameIndex(table: "dbo.Airroutes", name: "IX_ToAirportId", newName: "IX_ToAirport_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Airroutes", name: "IX_ToAirport_Id", newName: "IX_ToAirportId");
            RenameIndex(table: "dbo.Airroutes", name: "IX_FromAirport_Id", newName: "IX_FromAirportId");
            RenameColumn(table: "dbo.Airroutes", name: "ToAirport_Id", newName: "ToAirportId");
            RenameColumn(table: "dbo.Airroutes", name: "FromAirport_Id", newName: "FromAirportId");
        }
    }
}
