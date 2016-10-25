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
    public class ReservationticketsController : ApiController
    {
        private GenericRepository<Reservationticket> _reservationticketServices;
        private GenericRepository<Flight> _flightServices;
        private AirticketDataStore _unitOfWork;
        public ReservationticketsController()
        {
            this._unitOfWork = new AirticketDataStore();
            this._reservationticketServices = this._unitOfWork.Reservationtickets;
            this._flightServices = this._unitOfWork.Flights;
        }
        [HttpGet]
        public IHttpActionResult GetReservationticketclassById(string id)
        {
            Reservationticket res = null;
            if (id.Length > 6)
                res = this._reservationticketServices.GetById(id);
            else
                res = this._reservationticketServices.GetOne(r => r.Code == id);
            if (res != null)
                return Ok(res.To<ReservationticketDto>());
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetAllReservationticketclass()
        {
            var res = this._reservationticketServices.Get();
            if (res.Any())
                return Ok(res.To<ReservationticketDto>());
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult AddNewReservationticket([FromBody] ReservationticketDto reservationticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var flight = this._flightServices.GetById(reservationticketDto.Flight.Id);
            if (flight != null)
            {
                var reservationticket = new Reservationticket();
                reservationticket.Code = reservationticketDto.Code;
                reservationticket.Ticketclass = reservationticketDto.Ticketclass;
                reservationticket.Flight = flight;
                var res = this._reservationticketServices.Insert(reservationticket);
                if (res != null)
                    return Ok(res.To<ReservationticketDto>());
            }
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult EditReservationticket(string id, [FromBody] ReservationticketDto reservationticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var reservationticket = this._reservationticketServices.GetById(id);
            var flight = this._flightServices.GetById(reservationticketDto.Flight.Id);
            if (reservationticket != null
                && flight != null)
            {
                var customer = new Customer();
                customer.IdentityCode = reservationticketDto.Customer.IdentityCode;
                customer.Name = reservationticketDto.Customer.Name;
                customer.Phone = reservationticketDto.Customer.Phone;

                reservationticket.Customer = customer;
                reservationticket.Flight = flight;
                reservationticket.NumSeatBook = reservationticket.NumSeatBook;
                reservationticket.Status = reservationticketDto.Status;
                var res = this._reservationticketServices.Update(reservationticket);
                if (res != null)
                    return Ok(res.To<ReservationticketDto>());
            }
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult RemoveReservationticket(string id)
        {
            var reservationticket = this._reservationticketServices.GetById(id);
            if (reservationticket != null)
            {
                this._reservationticketServices.Delete(reservationticket);
                return Ok();
            }
            return BadRequest();
        }
    }
}
