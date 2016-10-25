using BanVeMayBay.Contracts;
using BanVeMayBay.DataStores;
using BanVeMayBay.DataTransferObjects;
using BanVeMayBay.Models;
using BanVeMayBay.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BanVeMayBay.Controllers
{
    [RoutePrefix("api/airports")]
    public class AirportsController : ApiController
    {
        private GenericRepository<Airport> _airportServices;
        private AirticketDataStore _unitOfWork;
        public AirportsController()
        {
            this._unitOfWork = new AirticketDataStore();
            this._airportServices = this._unitOfWork.Airports;
        }
        [HttpGet]
        public IHttpActionResult GetAllAirport()
        {
            var res = this._airportServices.Get();
            if (res.Any())
                return Ok(res.To<AirportDto>());
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetAirportById(string id)
        {
            var res = this._airportServices.GetById(id);
            if (res != null)
                return Ok(res.To<AirportDto>());
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult AddNewAirport([FromBody] AirportDto airportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var airport = new Airport();
            airport.Code = airportDto.Code;
            airport.Name = airportDto.Name;
            var res = this._airportServices.Insert(airport);
            if (res != null)
                return Ok(res.To<AirportDto>());
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult EditAirport(string id, [FromBody] AirportDto airportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var airport = this._airportServices.GetById(id);
            if(airport != null)
            {
                var res = this._airportServices.Update(airport);
                if (res != null)
                    return Ok(res.To<AirportDto>());
            }
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult RemoveAirport(string id)
        {
            var airport = this._airportServices.GetById(id);
            if (airport != null)
            {
                this._airportServices.Delete(airport);
                return Ok();
            }
            return BadRequest();
        }
    }
}
