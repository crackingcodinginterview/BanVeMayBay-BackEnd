using BanVeMayBay.Contracts;
using BanVeMayBay.Models;
using BanVeMayBay.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataStores
{
    public class AirticketDataStore : IUnitOfWork
    {
        private IRepository<Airport> airportRepository;
        public AirticketDataStore()
        {

        }
        public void Commit()
        {

        }
        public IRepository<Airport> Airports
        {
            get
            {
                if(airportRepository == null)
                {
                    airportRepository = new AirportRepository();
                }
                return airportRepository;
            }
        }
    }
}