using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataTransferObjects
{
    public class CustomerDto : BaseDto
    {
        public string IdentityCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ReservationticketId { get; set; }
    }
}