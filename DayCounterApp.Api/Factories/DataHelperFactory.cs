using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Helpers;
using DayCounterApp.Api.Interfaces;
using DayCounterApp.Api.Models.AppSettings;
using System;

namespace DayCounterApp.Api.Factories
{
    public static class DataHelperFactory<T> where T : class
    {
        public static IDataHelper<T> GetDataHelper(DataSource dataSource)
        {
            if (typeof(T) == typeof(IHoliday))
            {
                if (dataSource.Type.Equals(DataSourceTypeEn.Csv.ToString()))
                    return new CsvHelperHoliday(dataSource.ConnectionString) as CsvHelper<T>;
                else if (dataSource.Type.Equals(DataSourceTypeEn.Database.ToString()))
                    return new DbHelperHoliday() as DbHelper<T>;
                else
                    throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        public static IDataHelper<T> GetDataHelper(int srcType)
        {
            if (typeof(T) == typeof(IHoliday))
            {
                switch (srcType)
                {
                    case (int)DataSourceTypeEn.Csv:
                        return new CsvHelperHoliday() as CsvHelper<T>;
                    case (int)DataSourceTypeEn.Database:
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
                    case (int)DataSourceTypeEn.Csv:
                        return new CsvHelperHoliday(src) as CsvHelper<T>;
                    case (int)DataSourceTypeEn.Database:
                        return new DbHelperHoliday() as DbHelper<T>;
                    default:
                        throw new NotImplementedException();
                }
            }

            throw new NotImplementedException();
        }
    }
}
