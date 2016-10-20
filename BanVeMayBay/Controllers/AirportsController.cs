using BanVeMayBay.Contracts;
using BanVeMayBay.DataStores;
using BanVeMayBay.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BanVeMayBay.Controllers
{
    public class AirportsController : ApiController
    {
        private IUnitOfWork _unit;
        public AirportsController()
        {
            this._unit = new AirticketDataStore();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var res = this._unit.Airports.Get().First().To<AirportDto>();
            return Ok(res);
        }
    }
}
