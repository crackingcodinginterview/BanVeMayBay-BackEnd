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
        public virtual IEnumerable<T> Get()
        {
            return this._dataSet.ToList();
        }
        public virtual IEnumerable<T> Get(Func<T, Boolean> where)
        {
            return this._dataSet.Where(where).ToList();
        }
        public virtual T GetById(object id)
        {
            return this._dataSet.Find(id);
        }
        public virtual T GetOne(Func<T, Boolean> where)
        {
            return this._dataSet.Where(where).FirstOrDefault<T>();
        }
        public virtual T Insert(T model)
        {
            var res = this._dataSet.Add(model);
            this._dataContext.SaveChanges();
            return res;
        }
        public virtual void Delete(T model)
        {
            if (this._dataContext.Entry(model).State == EntityState.Detached)
            {
                this._dataSet.Attach(model);
            }
            this._dataSet.Remove(model);
            this._dataContext.SaveChanges();
        }
        public virtual T Update(T model)
        {
            this._dataSet.Attach(model);
            this._dataContext.Entry(model).State = EntityState.Modified;
            this._dataContext.SaveChanges();
            return model;
        }
    }
}