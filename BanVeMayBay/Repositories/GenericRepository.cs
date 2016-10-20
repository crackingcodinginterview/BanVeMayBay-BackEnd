using BanVeMayBay.Contracts;
using BanVeMayBay.DataContexts;
using BanVeMayBay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Repositories
{
    public class GenericRepository<T> where T : Base
    {
        private DbSet<T> _dataSet;
        private DbContext _dataContext;
        public GenericRepository(DbContext dataContext)
        {
            this._dataContext = dataContext;
            this._dataSet = this._dataContext.Set<T>();
        }
        public IEnumerable<T> Get()
        {
            return this._dataSet.ToList();
        }
        public T GetById(object id)
        {
            return this._dataSet.Find(id);
        }
        public T Insert(T model)
        {
            var res = this._dataSet.Add(model);
            return res;
        }
        public void Delete(object id)
        {
            T modelDelete = this._dataSet.Find(id);
            if (this._dataContext.Entry(modelDelete).State == EntityState.Detached)
            {
                this._dataSet.Attach(modelDelete);
            }
            this._dataSet.Remove(modelDelete);
        }
        public void Update(T model)
        {
            this._dataSet.Attach(model);
            this._dataContext.Entry(model).State = EntityState.Modified;
        }
    }
}