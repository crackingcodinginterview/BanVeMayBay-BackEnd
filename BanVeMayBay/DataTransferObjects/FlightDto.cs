using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataTransferObjects
{
    public class FlightDto
    {
        public string Code { get; set; }
        public DateTime Time { get; set; }
        public int NumSeat1 { get; set; }
        public int NumSeat2 { get; set; }
        public AirportDto StartAirport { get; set; }
        public AirportDto EndAirport { get; set; }
    }
}