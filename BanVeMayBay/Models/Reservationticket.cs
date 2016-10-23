﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Reservationticket
    {
        public string Code { get; set; }
        public DateTime BookDate { get; set; }
        public int NumSeatBook { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Ticketclass Ticketclass { get; set; }
    }
}