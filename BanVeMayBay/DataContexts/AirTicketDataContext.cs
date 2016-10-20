using BanVeMayBay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataContexts
{
    public class AirticketDataContext : DbContext
    {
        public AirticketDataContext()
        {

        }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Airroute> Airroute { get; set; }
    }
}