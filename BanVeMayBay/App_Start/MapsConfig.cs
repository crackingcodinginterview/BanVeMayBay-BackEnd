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
                .Include<Airport, AirportDto>()
                .Include<Airroute, AirrouteDto>();
            Mapper.CreateMap<Airport, AirportDto>()
                .ForSourceMember(s => s.Airroutes, s => s.Ignore());
            Mapper.CreateMap<Airroute, AirrouteDto>()
                .ForMember(d => d.FromAirport, d => d.MapFrom(s => s.Airports.ElementAt(0)))
                .ForMember(d => d.ToAirport, d => d.MapFrom(s => s.Airports.ElementAt(1)));
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