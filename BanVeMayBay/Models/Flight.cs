using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Flight : Base
    {
        [Required]
        [StringLength(5)]
        public string Code { get; set; }
        public DateTime Time { get; set; }
        public int NumSeat1 { get; set; }
        public int NumSeat2 { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
        public virtual ICollection<Reservationticket> Reservationtickets { get; set; }
    }
}