using BanVeMayBay.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Reservationticket : Base
    {
        public Reservationticket()
        {
            Status = 0;
            NumSeatBook = 0;
            BookDate = DateTime.Now;
        }
        [Required]
        [StringLength(6)]
        public string Code { get; set; }
        public DateTime BookDate { get; set; }
        public int NumSeatBook { get; set; }
        public BookStatus Status { get; set; } 
        public virtual Customer Customer { get; set; }
        public virtual Flight Flight { get; set; }
        public Ticketclass Ticketclass { get; set; }
    }
}