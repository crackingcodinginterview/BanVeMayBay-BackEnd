using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Customer : Base
    {
        [Required]
        public string IdentityCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public virtual Reservationticket Reservationticket { get; set; }
    }
}