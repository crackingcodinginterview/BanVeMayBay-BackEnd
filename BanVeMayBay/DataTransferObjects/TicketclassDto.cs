using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataTransferObjects
{
    public class TicketclassDto : BaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}