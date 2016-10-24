using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Airport : Base
    {
        [Required]
        [StringLength(3)]
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}