using BanVeMayBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
        IRepository<Airport> Airports { get; }
    }
}