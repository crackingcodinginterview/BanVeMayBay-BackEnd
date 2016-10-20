using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public abstract class Base
    {
        public Base()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        [Key]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}