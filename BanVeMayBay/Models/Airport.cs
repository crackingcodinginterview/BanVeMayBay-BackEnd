using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Models
{
    public class Airport : Base
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Airroute> Airroutes { get; set; }
    }
}