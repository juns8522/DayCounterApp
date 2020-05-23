using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Helpers;
using DayCounterApp.Api.Interfaces;
using System;

namespace DayCounterApp.Api.Factories
{
    public static class DataHelperFactory<T> where T : class
    {
        public static IDataHelper<T> GetDataHelper(int srcType)
        {
            if (typeof(T) == typeof(IHoliday))
            {
                switch (srcType)
                {
                    case (int)DataSourceTypeEn.CSV:
                        return new CsvHelperHoliday() as CsvHelper<T>;
                    case (int)DataSourceTypeEn.DATABASE:
                        return new DbHelperHoliday() as DbHelper<T>;
                    default:
                        throw new NotImplementedException();
                }
            }
            
            throw new NotImplementedException();
        }

        public static IDataHelper<T> GetDataHelper(int srcType, string src)
        {
            if (typeof(T) == typeof(IHoliday))
            {
                switch (srcType)
                {
                    case (int)DataSourceTypeEn.CSV:
                        return new CsvHelperHoliday(src) as CsvHelper<T>;
                    case (int)DataSourceTypeEn.DATABASE:
                        return new DbHelperHoliday() as DbHelper<T>;
                    default:
                        throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }
    }
}
