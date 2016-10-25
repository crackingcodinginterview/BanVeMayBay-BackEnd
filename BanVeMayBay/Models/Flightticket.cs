using BanVeMayBay.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Flightticket : Base
    {
        [Required]
        [StringLength(6)]
        public string Code { get; set; }
        public int Price { get; set; }
        public int NumSeatAvailable { get; set; }
        public Ticketclass Ticketclass { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}