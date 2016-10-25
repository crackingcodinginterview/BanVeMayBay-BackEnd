using BanVeMayBay.DataStores;
using BanVeMayBay.DataTransferObjects;
using BanVeMayBay.Enums;
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
    public class FlightticketsController : ApiController
    {
        private GenericRepository<Flightticket> _flightticketServices;
        private GenericRepository<Flight> _flightServices;
        private AirticketDataStore _unitOfWork;
        public FlightticketsController()
        {
            this._unitOfWork = new AirticketDataStore();
            this._flightticketServices = this._unitOfWork.Flighttickets;
            this._flightServices = this._unitOfWork.Flights;
        }
        [HttpGet]
        public IHttpActionResult GetAllFlightticket()
        {
            var res = this._flightticketServices.Get();
            if (res.Any())
                return Ok(res.To<FlightticketDto>());
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetFlightticketById(string id)
        {
            var res = this._flightticketServices.GetById(id);
            if (res != null)
                return Ok(res.To<FlightticketDto>());
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetBestTicket(
            string fromAirportId, string toAirportId,
            DateTime startDate,
            Ticketclass ticketclass = Ticketclass.Common,
            int numSeat = 1
            )
       {
            var res = this._flightticketServices.Get()
                .AsQueryable().Where(
                e => 
                e.Flight.Airports.ElementAt(0).Id == fromAirportId
                && e.Flight.Airports.ElementAt(1).Id == toAirportId
                && (e.Ticketclass == ticketclass && e.NumSeatAvailable >= numSeat)
                && e.Flight.Time >= startDate);
            if(res.Any())
                return Ok(res.To<FlightticketDto>());
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult AddNewFlightticket([FromBody] FlightticketDto flightticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var flightticket = new Flightticket();
            var flight = this._flightServices.GetById(flightticketDto.Flight.Id);
            if (flight != null)
            {
                flightticket.Code = flightticketDto.Code;
                flightticket.Flight = flight;
                flightticket.NumSeatAvailable = flightticketDto.NumSeatAvailable;
                flightticket.Price = flightticketDto.Price;
                flightticket.Ticketclass = flightticketDto.Ticketclass;
                var res = this._flightticketServices.Insert(flightticket);
                if (res != null)
                    return Ok(res.To<FlightticketDto>());
            }
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult EditFlightticket(string id, [FromBody] FlightticketDto flightticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var flightticket = this._flightticketServices.GetById(id);
            if (flightticket != null)
            {
                flightticket.Code = flightticketDto.Code;
                flightticket.Price = flightticketDto.Price;
                flightticket.Ticketclass = flightticketDto.Ticketclass;
                var res = this._flightticketServices.Update(flightticket);
                if (res != null)
                    return Ok(res.To<FlightticketDto>());
            }
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult RemoveFlightticket(string id)
        {
            var flightticket = this._flightticketServices.GetById(id);
            if (flightticket != null)
            {
                this._flightticketServices.Delete(flightticket);
                return Ok();
            }
            return BadRequest();
        }
    }
}
