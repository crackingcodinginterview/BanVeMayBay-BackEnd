using BanVeMayBay.Models;
using BanVeMayBay.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<Airport> Airports { get; }
        GenericRepository<Flight> Flights { get; }
        GenericRepository<Reservationticket> Reservationtickets { get; }
        GenericRepository<Customer> Customers { get; }
        GenericRepository<Flightticket> Flighttickets { get; }
    }
}