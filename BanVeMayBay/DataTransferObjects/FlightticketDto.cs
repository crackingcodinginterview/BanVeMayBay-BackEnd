using BanVeMayBay.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataTransferObjects
{
    public class FlightticketDto : BaseDto
    {
        public string Code { get; set; }
        public int Price { get; set; }
        public int NumSeatAvailable { get; set; }
        public Ticketclass Ticketclass { get; set; }
        public FlightDto Flight { get; set; }
    }
}