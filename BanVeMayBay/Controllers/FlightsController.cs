using BanVeMayBay.DataStores;
using BanVeMayBay.DataTransferObjects;
using BanVeMayBay.Models;
using BanVeMayBay.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BanVeMayBay.Controllers
{
    public class FlightsController : ApiController
    {
        private GenericRepository<Flight> _flightServices;
        private GenericRepository<Airport> _airportServices;
        private AirticketDataStore _unitOfWork;
        public FlightsController()
        {
            this._unitOfWork = new AirticketDataStore();
            this._flightServices = this._unitOfWork.Flights;
            this._airportServices = this._unitOfWork.Airports;
        }
        [HttpGet]
        public IHttpActionResult GetAllFlight()
        {
            var res = this._flightServices.Get();
            if (res.Any())
                return Ok(res.To<FlightDto>());
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetFlightById(string id)
        {
            var res = this._flightServices.GetById(id);
            if (res != null)
                return Ok(res.To<FlightDto>());
            return BadRequest();
        }
        [Authorize]
        [HttpPost]
        public IHttpActionResult AddNewFlight([FromBody] FlightDto flightDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var startAirport = this._airportServices.GetById(flightDto.StartAirport.Id);
            var endAirport = this._airportServices.GetById(flightDto.EndAirport.Id);
            if (startAirport != null &&
                endAirport != null)
            {
                var flight = new Flight();
                flight.Code = flightDto.Code;
                flight.Airports = new List<Airport> { startAirport, endAirport };
                flight.NumSeat1 = flightDto.NumSeat1;
                flight.NumSeat2 = flightDto.NumSeat2;
                flight.Time = flightDto.Time;
                var res = this._flightServices.Insert(flight);
                if (res != null)
                    return Ok(res.To<FlightDto>());
            }
            return BadRequest();
        }
        [Authorize]
        [HttpPut]
        public IHttpActionResult EditFlight(string id, [FromBody] FlightDto flightDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var flight = this._flightServices.GetById(id);
            if (flight != null)
            {
                flight.Code = flightDto.Code;
                flight.NumSeat1 = flightDto.NumSeat1;
                flight.NumSeat2 = flightDto.NumSeat2;
                flight.Time = flightDto.Time;
                var res = this._flightServices.Update(flight);
                if (res != null)
                    return Ok(res.To<FlightDto>());
            }
            return BadRequest();
        }
        [Authorize]
        [HttpDelete]
        public IHttpActionResult RemoveFlight(string id)
        {
            var flight = this._flightServices.GetById(id);
            if (flight != null)
            {
                this._flightServices.Delete(flight);
                return Ok();
            }
            return BadRequest();
        }
    }
}
