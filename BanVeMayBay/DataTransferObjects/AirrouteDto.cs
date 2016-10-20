namespace BanVeMayBay.DataTransferObjects
{
    public class AirrouteDto : BaseDto
    {
        public string Code { get; set; }
        public string FromAirportId { get; set; }
        public string ToAirportId { get; set; }
    }
}