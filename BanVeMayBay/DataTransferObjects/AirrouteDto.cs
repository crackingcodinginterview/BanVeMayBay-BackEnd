namespace BanVeMayBay.DataTransferObjects
{
    public class AirrouteDto : BaseDto
    {
        public string Code { get; set; }
        public AirportDto FromAirport { get; set; }
        public AirportDto ToAirport { get; set; }
    }
}