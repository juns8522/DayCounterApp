using DayCounterApp.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DayCounterApp.Api.Helpers
{
    public abstract class DbHelper<T> : IDataHelper<T> where T : class
    {
        public virtual Task<T> Add(T t)
        {
            throw new NotImplementedException();
        }

        public virtual Task Delete()
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> Update()
        {
            throw new NotImplementedException();
        }
    }
}
