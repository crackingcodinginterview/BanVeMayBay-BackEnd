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
                .Include<Flight, FlightDto>()
                .Include<Reservationticket, ReservationticketDto>()
                .Include<Customer, CustomerDto>();
            Mapper.CreateMap<Airport, AirportDto>()
                .ForSourceMember(s => s.Flights, s => s.Ignore());
            Mapper.CreateMap<Customer, CustomerDto>()
                .ForSourceMember(s => s.Reservationticket, s => s.Ignore())
                .ForMember(s => s.ReservationticketId, s => s.MapFrom(d => d.Reservationticket.Id));
            Mapper.CreateMap<Flight, FlightDto>()
                .ForSourceMember(s => s.Reservationtickets, s => s.Ignore())
                .ForSourceMember(s => s.Airports, s => s.Ignore())
                .ForMember(d => d.StartAirport, d => d.MapFrom(s => s.Airports.ElementAt(0)))
                .ForMember(d => d.EndAirport, d => d.MapFrom(s => s.Airports.ElementAt(1)));
            Mapper.CreateMap<Reservationticket, ReservationticketDto>();
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