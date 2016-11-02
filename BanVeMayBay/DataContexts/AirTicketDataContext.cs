using BanVeMayBay.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataContexts
{
    public class AirticketDataContext : IdentityDbContext
    {
        public AirticketDataContext() : base("airticket")
        {

        }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Reservationticket> Reservationticket { get; set; }
        public DbSet<Flightticket> Flightticket { get; set; }
        public DbSet<User> Users { get; set; }
    }
}