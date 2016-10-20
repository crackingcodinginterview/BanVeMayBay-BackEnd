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
        GenericRepository<Airroute> Airroutes { get; }
    }
}