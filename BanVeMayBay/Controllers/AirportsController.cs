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
        public IHttpActionResult GetAllAirport()
        {
            var res = this._unit.Airports.Get();
            return Ok(res);
        }

        [HttpGet]
        public IHttpActionResult GetAirportById(string id)
        {
            var res = this._unit.Airports.GetById(id).To<AirportDto>();
            return Ok(res);
        }
    }
}
