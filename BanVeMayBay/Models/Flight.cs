using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Flight
    {
        public string Code { get; set; }
        public DateTime Time { get; set; }
        public int NumSeat1 { get; set; }
        public int NumSeat2 { get; set; }
    }
}