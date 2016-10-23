using BanVeMayBay.Contracts;
using BanVeMayBay.DataStores;
using BanVeMayBay.DataTransferObjects;
using BanVeMayBay.Models;
using BanVeMayBay.Services;
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
        private IAirportServices _airportServices;
        public AirportsController()
        {
            this._airportServices = new AirportServices();
        }
        [HttpGet]
        public IHttpActionResult GetAllAirport()
        {
            var res = this._airportServices.GetAllAirport();
            if (res.Any())
                return Ok(res);
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetAirportById(string id)
        {
            var res = this._airportServices.GetAirportById(id);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult AddNewAirport([FromBody] AirportDto airportDto)
        {
            var res = this._airportServices.AddNewAirport(airportDto);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult EditAirport(string id, [FromBody] AirportDto airportDto)
        {
            var res = this._airportServices.UpdateAirport(id, airportDto);
            if (res != null)
                return Ok(res);
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult RemoveAirport(string id)
        {
            var res = this._airportServices.DeleteAirport(id);
            if (res == true)
                return Ok();
            return BadRequest();
        }
    }
}
