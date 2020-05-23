using DayCounterApp.Api.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Models;

namespace DayCounterApp.Api
{
    public class DayCounter
    {
        public IEnumerable<IHoliday> Holidays { get; set; }

        public DayCounter()
        {}

        public DayCounter(IEnumerable<IHoliday> holidays)
        {
            Holidays = holidays;
        }

        //Excluding fromDt and toDt
        public async Task<int> GetWorkingDays(DateTime fromDt, DateTime toDt)
        {
            fromDt = fromDt.Date.AddDays(1);
            toDt = toDt.Date.AddDays(-1);

            if (toDt <= fromDt)
                return 0;

            return GetWeekDays(fromDt, toDt) - await GetNumHolidaysInWeekdays(fromDt, toDt);
        }

        //Including fromDt and toDt
        public int GetWeekDays(DateTime fromDt, DateTime toDt)
        {
            var diffTimeSpan = toDt - fromDt;
            int days = diffTimeSpan.Days + 1;
            return days - GetWeekendDays(fromDt, days);
        }

        //Including fromDt and toDt
        public int GetWeekendDays(DateTime fromDt, int totalDays)
        {
            int weeks = totalDays / 7;
            int days = totalDays % 7;

            //full week
            if (days == 0)
                return weeks * 2;

            //non-full week
            int numDays = 7 - (int)fromDt.DayOfWeek;
            int additionDays = 0;

            if (fromDt.DayOfWeek == DayOfWeek.Sunday)
                additionDays = 1;
            else if (days == numDays)
                additionDays = 1;
            else if (days > numDays)
                additionDays = 2;
            
            return weeks * 2 + additionDays;
        }

        //Including fromDt and toDt
        public async Task<int> GetNumHolidaysInWeekdays(DateTime fromDt, DateTime toDt)
        {
            int numHolidays = 0;
            if (Holidays == null || Holidays.Count() == 0)
                return numHolidays;

            List<Task<int>> tasks = new List<Task<int>>();
            int year = fromDt.Year;

            while (year <= toDt.Year)
            {
                DateTime startDt = new DateTime(year, 1, 1);
                DateTime endDt = new DateTime(year, 12, 31);

                if (year == fromDt.Year && startDt < fromDt)
                    startDt = fromDt;
                if (year == toDt.Year && endDt > toDt)
                    endDt = toDt;

                //build a task list
                tasks.Add(Task.FromResult(GetNumHolidaysInWeekdays(startDt, endDt, year)));

                year++;
            }

            foreach (var num in await Task.WhenAll(tasks))
            {
                numHolidays  += num;
            }

            return numHolidays;
        }

        public int GetNumHolidaysInWeekdays(DateTime fromDt, DateTime toDt, int year)
        {
            int count = 0;

            foreach(var holiday in Holidays)
            {
                if(holiday.Type == (int)HolidayTypeEn.FixedDate)
                {
                    if (IsHolidayFixedDateInWeekdays(fromDt, toDt, year, (Holiday)holiday))
                        count++;
                }
                else if (holiday.Type == (int)HolidayTypeEn.FixedWeekday)
                {
                    if (IsHolidayFixedWeekdayInWeekdays(fromDt, toDt, year, (HolidayFixedWeekday)holiday))
                        count++;
                }
                else if (holiday.Type == (int)HolidayTypeEn.AdditionalDate)
                {
                    if (IsHolidayAdditionalDateInWeekdays(fromDt, toDt, year, (HolidayAdditionalDate)holiday))
                        count++;
                }
            }

            return count;
        }

        public bool IsHolidayFixedDateInWeekdays(DateTime fromDt, DateTime toDt, int year, Holiday holiday)
        {
            var dt = new DateTime(year, holiday.Month, holiday.Day);
            if (dt >= fromDt && dt <= toDt && dt.DayOfWeek > DayOfWeek.Sunday && dt.DayOfWeek < DayOfWeek.Saturday)
                return true;
            return false;
        }

        public bool IsHolidayFixedWeekdayInWeekdays(DateTime fromDt, DateTime toDt, int year, HolidayFixedWeekday holiday)
        {
            if (holiday.DayOfWeek == (int)DayOfWeek.Sunday || holiday.DayOfWeek == (int)DayOfWeek.Saturday)
                return false;

            var dt = GetHolidayFixedWeekday(year, holiday);

            if(dt >= fromDt && dt <= toDt)
                return true;
            return false;
        }

        public bool IsHolidayAdditionalDateInWeekdays(DateTime fromDt, DateTime toDt, int year, HolidayAdditionalDate holiday)
        {
            return true;
        }

        public DateTime GetHolidayFixedWeekday(int year, HolidayFixedWeekday holiday)
        {
            var dt = new DateTime(year, holiday.Month, 1);

            int additionalDays = holiday.DayOfWeek - (int)dt.DayOfWeek;

            if (additionalDays < 0)
                additionalDays += 7;

            dt = dt.AddDays(additionalDays);

            int nthWeek = 1;
            while (nthWeek < holiday.Week)
            {
                dt = dt.AddDays(7);
                nthWeek++;
            }

            return dt;
        }
    }
}
