using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Interfaces;
using DayCounterApp.Api.Models;
using System.IO;

namespace DayCounterApp.Api.Factories
{
    public static class HolidayFactory
    {
        public static IHoliday GetHoliday(int type)
        {
            switch(type)
            {
                case (int)HolidayTypeEn.FIXED_DATE:
                    return new Holiday();
                case (int)HolidayTypeEn.FIXED_WEEKDAY:
                    return new HolidayFixedWeekday();
                case (int)HolidayTypeEn.ADDITIONAL_DATE:
                    return new HolidayAdditionalDate();
                default:
                    throw new InvalidDataException();
            }
        }

        public static IHoliday GetHoliday(string[] arr)
        {
            int type = int.Parse(arr[2]);

            switch (type)
            {
                case (int)HolidayTypeEn.FIXED_DATE:
                    return new Holiday(arr);
                case (int)HolidayTypeEn.FIXED_WEEKDAY:
                    return new HolidayFixedWeekday(arr);
                case (int)HolidayTypeEn.ADDITIONAL_DATE:
                    return new HolidayAdditionalDate(arr);
                default:
                    throw new InvalidDataException();
            }
        }
    }
}
