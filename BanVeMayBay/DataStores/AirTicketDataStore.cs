﻿using BanVeMayBay.Contracts;
using BanVeMayBay.DataContexts;
using BanVeMayBay.Models;
using BanVeMayBay.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace BanVeMayBay.DataStores
{
    public class AirticketDataStore : IUnitOfWork
    {
        private DbContext _dataContext;
        private GenericRepository<Airport> _airports;
        private GenericRepository<Flight> _flights;
        public AirticketDataStore()
        {
            this._dataContext = new AirticketDataContext();
        }
        public GenericRepository<Airport> Airports
        {
            get
            {
                if(this._airports == null)
                {
                    this._airports = new GenericRepository<Airport>(this._dataContext);
                }
                return this._airports;
            }
        }

        public GenericRepository<Flight> Flights
        {
            get
            {
                if (this._flights == null)
                {
                    this._flights = new GenericRepository<Flight>(this._dataContext);
                }
                return this._flights;
            }
        }

        public void Save()
        {
            try
            {
                this._dataContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

            }
        }
    }
}