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
    public class AirroutesController : ApiController
    {
        private IUnitOfWork _unit;
        public AirroutesController()
        {
            this._unit = new AirticketDataStore();
        }
        [HttpGet]
        public IHttpActionResult GetAllAirroute()
        {
            var res = this._unit.Airports.Get().To<AirrouteDto>();
            return Ok(res);
        }

        [HttpGet]
        public IHttpActionResult GetAirrouteById(string id)
        {
            var res = this._unit.Airports.GetById(id).To<AirportDto>();
            return Ok(res);
        }
    }
}
