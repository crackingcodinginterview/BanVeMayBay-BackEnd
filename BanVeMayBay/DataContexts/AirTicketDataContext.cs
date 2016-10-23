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
        public AirticketDataContext() : base("airticket")
        {

        }
        public DbSet<Airport> Airport { get; set; }
    }
}