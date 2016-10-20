using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataTransferObjects
{
    public class AirportDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AirrouteDto> Airroutes { get; set; }
    }
}