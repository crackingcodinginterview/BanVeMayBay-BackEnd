using BanVeMayBay.Contracts;
using BanVeMayBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Repositories
{
    public class AirportRepository : IRepository<Airport>
    {
        public List<Airport> list;
        public AirportRepository()
        {
            var airPort1 = new Airport { Id = "1", Name = "Sân Bay HCM" };
            var airPort2 = new Airport { Id = "2", Name = "Sân Bay Đà Nẵng" };
            Airroute airroute = new Airroute { Id = "1", From = airPort1, Fromid = airPort1.Id, To = airPort2 , Toid = airPort2.Id};
            airPort1.Airroutes = new List<Airroute> { airroute };
            airPort2.Airroutes = new List<Airroute> { airroute };
            list = new List<Airport>
            {
                airPort1,
                airPort2
            };
        }

        public IEnumerable<Airport> GetAll()
        {
            return list.AsEnumerable();
        }
    }
}