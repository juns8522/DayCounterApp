using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Interfaces;
using System.IO;

namespace DayCounterApp.Api.Models
{
    public class HolidayFixedWeekday : IHoliday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }
        public int DayOfWeek { get; set; }
        public HolidayFixedWeekday()
        {
            Type = (int)HolidayTypeEn.FixedWeekday;
        }
        public HolidayFixedWeekday(string[] arr) 
        {
            int num;
            if (int.TryParse(arr[0], out num)) Id = num;
            else throw new InvalidDataException();

            Name = arr[1];

            if (int.TryParse(arr[2], out num)) Type = num;
            else throw new InvalidDataException();

            if (int.TryParse(arr[3], out num)) Month = num;
            else throw new InvalidDataException();

            if (int.TryParse(arr[4], out num)) Week = num;
            else throw new InvalidDataException();

            if (int.TryParse(arr[5], out num)) DayOfWeek = num;
            else throw new InvalidDataException();
        }
    }
}
