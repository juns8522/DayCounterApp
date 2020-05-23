using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Interfaces;
using System.IO;

namespace DayCounterApp.Api.Models
{
    public class HolidayAdditionalDate : IHoliday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public HolidayAdditionalDate()
        {
            Type = (int)HolidayTypeEn.AdditionalDate;
        }
        public HolidayAdditionalDate(string[] arr) 
        {
            int num;
            if (int.TryParse(arr[0], out num)) Id = num;
            else throw new InvalidDataException();

            Name = arr[1];

            if (int.TryParse(arr[2], out num)) Type = num;
            else throw new InvalidDataException();

            if (int.TryParse(arr[3], out num)) Month = num;
            else throw new InvalidDataException();

            if (int.TryParse(arr[4], out num)) Day = num;
            else throw new InvalidDataException();
        }
    }
}
