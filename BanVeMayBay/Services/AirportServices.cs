using BanVeMayBay.Contracts;
using BanVeMayBay.DataStores;
using BanVeMayBay.DataTransferObjects;
using BanVeMayBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace BanVeMayBay.Services
{
    public class AirportServices : IAirportServices
    {
        private IUnitOfWork _unitOfWork;
        public AirportServices()
        {
            this._unitOfWork = new AirticketDataStore();
        }
        public AirportDto GetAirportById(string id)
        {
            var airport = this._unitOfWork.Airports.GetById(id);
            if(airport != null)
                return airport.To<AirportDto>();
            return null;
        }
        public IEnumerable<AirportDto> GetAllAirport()
        {
            var airports = this._unitOfWork.Airports.Get().ToList();
            if (airports.Any())
                return airports.To<AirportDto>();
            return null;
        }
        public AirportDto AddNewAirport(AirportDto airportDto)
        {
            using(var scope = new TransactionScope())
            {
                var airport = airportDto.To<Airport>();
                this._unitOfWork.Airports.Insert(airport);
                this._unitOfWork.Save();
                scope.Complete();
                return airportDto;
            }
        }
        public AirportDto UpdateAirport(string id, AirportDto airportDto)
        {
            using (var scope = new TransactionScope())
            {
                var airport = this._unitOfWork.Airports.GetById(id);
                if(airport != null)
                {
                    airport.Name = airportDto.Name;
                    airport.Code = airportDto.Code;
                    this._unitOfWork.Airports.Update(airport);
                    this._unitOfWork.Save();
                    scope.Complete();
                    return airportDto;
                }
                return null;
            }
        }
        public bool DeleteAirport(string id)
        {
            var success = false;
            using (var scope = new TransactionScope())
            {
                var airport = this._unitOfWork.Airports.GetById(id);
                if (airport != null)
                {
                    this._unitOfWork.Airports.Delete(airport);
                    this._unitOfWork.Save();
                    scope.Complete();
                    success = true;
                }
            }
            return success;
        }
    }
}