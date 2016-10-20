namespace BanVeMayBay.Models
{
    public class Airroute : Base
    {
        public string Code { get; set; }
        public virtual Airport FromAirport { get; set; }
        public string FromAirportId { get; set; }
        public virtual Airport ToAirport { get; set; }
        public string ToAirportId { get; set; }
    }
}