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
    public class TicketclassController : ApiController
    {
        private GenericRepository<Ticketclass> _ticketclassServices;
        private AirticketDataStore _unitOfWork;
        public TicketclassController()
        {
            this._unitOfWork = new AirticketDataStore();
            this._ticketclassServices = this._unitOfWork.Ticketclasss;
        }
        [HttpGet]
        public IHttpActionResult GetAllTicketclass()
        {
            var res = this._ticketclassServices.Get();
            if (res.Any())
                return Ok(res.To<TicketclassDto>());
            return BadRequest();
        }
        [HttpGet]
        public IHttpActionResult GetTicketclassById(string id)
        {
            var res = this._ticketclassServices.GetById(id);
            if (res != null)
                return Ok(res.To<TicketclassDto>());
            return BadRequest();
        }
        [HttpPost]
        public IHttpActionResult AddNewTicketclass([FromBody] TicketclassDto ticketclassDto)
        {
            var ticketclass = new Ticketclass();
            ticketclass.Code = ticketclassDto.Code;
            ticketclass.Name = ticketclassDto.Name;
            var res = this._ticketclassServices.Insert(ticketclass);
            if (res != null)
                return Ok(res.To<TicketclassDto>());
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult EditTicketclass(string id, [FromBody] TicketclassDto ticketclassDto)
        {
            var ticketclass = this._ticketclassServices.GetById(id);
            if (ticketclass != null)
            {
                var res = this._ticketclassServices.Update(ticketclass);
                if (res != null)
                    return Ok(res.To<TicketclassDto>());
            }
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult RemoveTicketclass(string id)
        {
            var ticketclass = this._ticketclassServices.GetById(id);
            if (ticketclass != null)
            {
                this._ticketclassServices.Delete(ticketclass);
                return Ok();
            }
            return BadRequest();
        }
    }
}
