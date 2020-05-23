using DayCounterApp.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DayCounterApp.Api.Helpers
{
    public class DbHelperHoliday : DbHelper<IHoliday>
    {
        public override Task<IHoliday> Add(IHoliday holiday)
        {
            throw new NotImplementedException();
        }

        public override Task Delete()
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<IHoliday>> Get()
        {
            throw new NotImplementedException();
        }

        public override Task<IHoliday> Get(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IHoliday> Update()
        {
            throw new NotImplementedException();
        }
    }
}
