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
    public class CustomersController : ApiController
    {
        private GenericRepository<Customer> _customerServices;
        private GenericRepository<Reservationticket> _reservationServices;
        private AirticketDataStore _unitOfWork;
        public CustomersController()
        {
            this._unitOfWork = new AirticketDataStore();
            this._customerServices = this._unitOfWork.Customers;
            this._reservationServices = this._unitOfWork.Reservationtickets;
        }
        [HttpGet]
        public IHttpActionResult GetAllCustomer()
        {
            var res = this._customerServices.Get();
            if (res.Any())
                return Ok(res.To<CustomerDto>());
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetCustomerById(string id)
        {
            var res = this._customerServices.GetById(id);
            if (res != null)
                return Ok(res.To<CustomerDto>());
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult AddNewCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var reservationticket = this._reservationServices.GetById(customerDto.ReservationticketId);
            if (reservationticket != null)
            {
                var customer = new Customer();
                customer.IdentityCode = customerDto.IdentityCode;
                customer.Name = customerDto.Name;
                customer.Phone = customerDto.Phone;
                customer.Reservationticket = reservationticket;
                var res = this._customerServices.Insert(customer);
                if (res != null)
                    return Ok(res.To<CustomerDto>());
            }
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult EditCustomer(string id, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = this._customerServices.GetById(id);
            if (customer != null)
            {
                var res = this._customerServices.Update(customer);
                if (res != null)
                    return Ok(res.To<CustomerDto>());
            }
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult RemoveCustomer(string id)
        {
            var customer = this._customerServices.GetById(id);
            if (customer != null)
            {
                this._customerServices.Delete(customer);
                return Ok();
            }
            return BadRequest();
        }
    }
}
