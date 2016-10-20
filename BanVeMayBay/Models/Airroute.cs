using System.Collections.Generic;

namespace BanVeMayBay.Models
{
    public class Airroute : Base
    {
        public string Code { get; set; }
        public virtual ICollection<Airport> Airports { get; set; }
    }
}