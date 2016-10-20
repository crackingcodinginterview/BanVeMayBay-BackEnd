using BanVeMayBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanVeMayBay.Contracts
{
    public interface IRepository<T> where T : Base
    {
        IEnumerable<T> Get();
        T GetById(object Id);
        T Insert(T Model);
        void Delete(object Id);
        void Update(T Model);
    }
}