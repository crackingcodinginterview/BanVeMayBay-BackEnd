using AutoMapper;
using BanVeMayBay.DataTransferObjects;
using BanVeMayBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay
{
    public static class MapsConfig
    {
        public static void Register()
        {
            Mapper.CreateMap<Base, BaseDto>()
                .ForSourceMember(s => s.CreatedDate, s => s.Ignore())
                .ForSourceMember(s => s.UpdatedDate, s => s.Ignore())
                .Include<Airport, AirportDto>()
                .Include<Ticketclass, TicketclassDto>()
                .Include<Flight, FlightDto>();
            Mapper.CreateMap<Airport, AirportDto>()
                .ForSourceMember(s => s.Flights, s => s.Ignore());
            Mapper.CreateMap<Ticketclass, TicketclassDto>()
                .ForSourceMember(s => s.Reservationtickets, s => s.Ignore());
        }
        public static T To<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
        public static IEnumerable<T> To<T>(this IEnumerable<object> source)
        {
            return Mapper.Map<IEnumerable<T>>(source);
        }
    }
}