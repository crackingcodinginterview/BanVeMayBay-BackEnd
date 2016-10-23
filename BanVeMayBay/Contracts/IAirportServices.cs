using BanVeMayBay.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Contracts
{
    public interface IAirportServices
    {
        AirportDto GetAirportById(string id);
        IEnumerable<AirportDto> GetAllAirport();
        AirportDto AddNewAirport(AirportDto airportDto);
        AirportDto UpdateAirport(string id, AirportDto airportDto);
        bool DeleteAirport(string id);
    }
}