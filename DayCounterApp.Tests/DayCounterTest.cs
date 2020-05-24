using DayCounterApp.Api.Interfaces;
using DayCounterApp.Api.Models;
using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DayCounterApp.Api;

namespace DayCounterApp.Tests
{
    class DayCounterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test01_WeekDays()
        {
            var dayCounter = new DayCounter();

            var frDt = new DateTime(2020, 1, 1);
            var toDt = new DateTime(2020, 1, 4);
            var days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 3);

            frDt = new DateTime(2020, 1, 1);
            toDt = new DateTime(2020, 1, 5);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 3);

            frDt = new DateTime(2020, 5, 23);
            toDt = new DateTime(2020, 5, 30);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 5);

            frDt = new DateTime(2020, 5, 24);
            toDt = new DateTime(2020, 5, 30);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 5);

            frDt = new DateTime(2020, 5, 25);
            toDt = new DateTime(2020, 5, 30);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 5);

            frDt = new DateTime(2020, 5, 23);
            toDt = new DateTime(2020, 5, 29);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 5);

            frDt = new DateTime(2020, 5, 24);
            toDt = new DateTime(2020, 5, 29);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 5);

            frDt = new DateTime(2020, 5, 25);
            toDt = new DateTime(2020, 5, 30);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 5);

            frDt = new DateTime(2020, 5, 26);
            toDt = new DateTime(2020, 5, 31);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 4);

            frDt = new DateTime(2020, 1, 1);
            toDt = new DateTime(2020, 12, 31);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 262);

            frDt = new DateTime(2019, 1, 1);
            toDt = new DateTime(2019, 12, 31);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 261);

            frDt = new DateTime(2019, 1, 1);
            toDt = new DateTime(2020, 12, 31);
            days = dayCounter.GetWeekDays(frDt, toDt);
            Assert.IsTrue(days == 523);
        }

        [Test]
        public void Test02_GetHolidayFixedDate()
        {
            var dayCounter = new DayCounter();

            var holiday = new Holiday
            {
                Id = 0,
                Name = "Anzac Day",
                Type = (int)HolidayTypeEn.FixedDate,
                Month = 4,
                Day = 25
            };

            var frDt = new DateTime(2015, 1, 1);
            var toDt = new DateTime(2020, 12, 31);

            var result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2020, holiday);
            Assert.IsTrue(result == false);

            result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2019, holiday);
            Assert.IsTrue(result == true);

            result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2018, holiday);
            Assert.IsTrue(result == true);

            result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2017, holiday);
            Assert.IsTrue(result == true);

            result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2016, holiday);
            Assert.IsTrue(result == true);

            result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2015, holiday);
            Assert.IsTrue(result == false);

            toDt = new DateTime(2020, 4, 14);
            result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2020, holiday);
            Assert.IsTrue(result == false);

            frDt = new DateTime(2020, 5, 14);
            toDt = new DateTime(2020, 6, 14);
            result = dayCounter.IsHolidayFixedDateInWeekdays(frDt, toDt, 2020, holiday);
            Assert.IsTrue(result == false);
        }

        [Test]
        public void Test03_GetHolidayFixedWeekday()
        {
            var dayCounter = new DayCounter();

            var holiday = new HolidayFixedWeekday
            {
                Id = 0,
                Name = "Queen's Birthday",
                Type = (int)HolidayTypeEn.FixedWeekday,
                Month = 6,
                Week = 2,
                DayOfWeek = (int)DayOfWeek.Monday
            };
            
            var dt = dayCounter.GetHolidayFixedWeekday(2020, holiday);
            Assert.IsTrue(dt.Year == 2020);
            Assert.IsTrue(dt.Month == 6);
            Assert.IsTrue(dt.Day == 8);
            Assert.IsTrue(dt.DayOfWeek == DayOfWeek.Monday);

            var dt2 = dayCounter.GetHolidayFixedWeekday(2019, holiday);
            Assert.IsTrue(dt2.Year == 2019);
            Assert.IsTrue(dt2.Month == 6);
            Assert.IsTrue(dt2.Day == 10);
            Assert.IsTrue(dt2.DayOfWeek == DayOfWeek.Monday);

            var dt3 = dayCounter.GetHolidayFixedWeekday(2018, holiday);
            Assert.IsTrue(dt3.Year == 2018);
            Assert.IsTrue(dt3.Month == 6);
            Assert.IsTrue(dt3.Day == 11);
            Assert.IsTrue(dt3.DayOfWeek == DayOfWeek.Monday);

            var dt4 = dayCounter.GetHolidayFixedWeekday(2017, holiday);
            Assert.IsTrue(dt4.Year == 2017);
            Assert.IsTrue(dt4.Month == 6);
            Assert.IsTrue(dt4.Day == 12);
            Assert.IsTrue(dt4.DayOfWeek == DayOfWeek.Monday);

            var dt5 = dayCounter.GetHolidayFixedWeekday(2016, holiday);
            Assert.IsTrue(dt5.Year == 2016);
            Assert.IsTrue(dt5.Month == 6);
            Assert.IsTrue(dt5.Day == 13);
            Assert.IsTrue(dt5.DayOfWeek == DayOfWeek.Monday);

            var dt6 = dayCounter.GetHolidayFixedWeekday(2015, holiday);
            Assert.IsTrue(dt6.Year == 2015);
            Assert.IsTrue(dt6.Month == 6);
            Assert.IsTrue(dt6.Day == 8);
            Assert.IsTrue(dt6.DayOfWeek == DayOfWeek.Monday);
        }

        [Test]
        public void Test04_GetHolidayFixedWeekday()
        {
            var dayCounter = new DayCounter();

            var holiday = new HolidayFixedWeekday
            {
                Id = 0,
                Name = "Queen's Birthday",
                Type = (int)HolidayTypeEn.FixedWeekday,
                Month = 6,
                Week = 2,
                DayOfWeek = (int)DayOfWeek.Monday
            };

            var dt = dayCounter.GetHolidayFixedWeekday(2020, holiday);
            Assert.IsTrue(dt.Year == 2020);
            Assert.IsTrue(dt.Month == 6);
            Assert.IsTrue(dt.Day == 8);
            Assert.IsTrue(dt.DayOfWeek == DayOfWeek.Monday);

            var dt2 = dayCounter.GetHolidayFixedWeekday(2019, holiday);
            Assert.IsTrue(dt2.Year == 2019);
            Assert.IsTrue(dt2.Month == 6);
            Assert.IsTrue(dt2.Day == 10);
            Assert.IsTrue(dt2.DayOfWeek == DayOfWeek.Monday);

            var dt3 = dayCounter.GetHolidayFixedWeekday(2018, holiday);
            Assert.IsTrue(dt3.Year == 2018);
            Assert.IsTrue(dt3.Month == 6);
            Assert.IsTrue(dt3.Day == 11);
            Assert.IsTrue(dt3.DayOfWeek == DayOfWeek.Monday);

            var dt4 = dayCounter.GetHolidayFixedWeekday(2017, holiday);
            Assert.IsTrue(dt4.Year == 2017);
            Assert.IsTrue(dt4.Month == 6);
            Assert.IsTrue(dt4.Day == 12);
            Assert.IsTrue(dt4.DayOfWeek == DayOfWeek.Monday);

            var dt5 = dayCounter.GetHolidayFixedWeekday(2016, holiday);
            Assert.IsTrue(dt5.Year == 2016);
            Assert.IsTrue(dt5.Month == 6);
            Assert.IsTrue(dt5.Day == 13);
            Assert.IsTrue(dt5.DayOfWeek == DayOfWeek.Monday);

            var dt6 = dayCounter.GetHolidayFixedWeekday(2015, holiday);
            Assert.IsTrue(dt6.Year == 2015);
            Assert.IsTrue(dt6.Month == 6);
            Assert.IsTrue(dt6.Day == 8);
            Assert.IsTrue(dt6.DayOfWeek == DayOfWeek.Monday);
        }

        [Test]
        public void Test05_IsHolidayFixedWeekdayInWeekdays()
        {
            var dayCounter = new DayCounter();

            var holiday = new HolidayFixedWeekday
            {
                Id = 0,
                Name = "Queen's Birthday",
                Type = (int)HolidayTypeEn.FixedWeekday,
                Month = 6,
                Week = 2,
                DayOfWeek = (int)DayOfWeek.Monday
            };

            var frDt = new DateTime(2015, 1, 1);
            var toDt = new DateTime(2020, 12, 31);
            DateTime actualDate;
            var result = dayCounter.IsHolidayFixedWeekdayInWeekdays(frDt, toDt, 2020, holiday, out actualDate);
            Assert.IsTrue(result);
            Assert.IsTrue(actualDate.Year == 2020);
            Assert.IsTrue(actualDate.Month == 6);
            Assert.IsTrue(actualDate.Day == 8);

            toDt = new DateTime(2020, 6, 1);
            result = dayCounter.IsHolidayFixedWeekdayInWeekdays(frDt, toDt, 2020, holiday, out actualDate);
            Assert.IsFalse(result);

            frDt = new DateTime(2020, 7, 1);
            toDt = new DateTime(2020, 12, 31);
            result = dayCounter.IsHolidayFixedWeekdayInWeekdays(frDt, toDt, 2020, holiday, out actualDate);
            Assert.IsFalse(result);
        }

        [Test]
        public void Test06_GetNumHolidayAdditionalDateInMonth()
        {
            var dayCounter = new DayCounter();
            SortedList<int, HolidayAdditionalDate> list = new SortedList<int, HolidayAdditionalDate>();
            list.Add(26, new HolidayAdditionalDate
            {
                Id = 0,
                Name = "Boxing Day",
                Type = (int)HolidayTypeEn.AdditionalDate,
                Month = 12,
                Day = 26
            });
            list.Add(25, new HolidayAdditionalDate
            {
                Id = 0,
                Name = "Christmas Day",
                Type = (int)HolidayTypeEn.AdditionalDate,
                Month = 12,
                Day = 25
            });
            var frDt = new DateTime(2020, 1, 1);
            var toDt = new DateTime(2021, 12, 31);
            var year = 2020;
            var days = new int[32];

            var num = dayCounter.GetNumHolidayAdditionalDateInMonth(frDt, toDt, year, days, list);
            Assert.IsTrue(num == 2);

            var days2 = new int[32];
            toDt = new DateTime(2020, 12, 28);
            num = dayCounter.GetNumHolidayAdditionalDateInMonth(frDt, toDt, year, days2, list);
            Assert.IsTrue(num == 2);

            var days3 = new int[32];
            toDt = new DateTime(2020, 12, 27);
            num = dayCounter.GetNumHolidayAdditionalDateInMonth(frDt, toDt, year, days3, list);
            Assert.IsTrue(num == 1);

            var days4 = new int[32];
            toDt = new DateTime(2020, 12, 26);
            num = dayCounter.GetNumHolidayAdditionalDateInMonth(frDt, toDt, year, days4, list);
            Assert.IsTrue(num == 1);

            var days5 = new int[32];
            toDt = new DateTime(2020, 12, 25);
            num = dayCounter.GetNumHolidayAdditionalDateInMonth(frDt, toDt, year, days5, list);
            Assert.IsTrue(num == 1);

            var days6 = new int[32];
            toDt = new DateTime(2020, 12, 24);
            num = dayCounter.GetNumHolidayAdditionalDateInMonth(frDt, toDt, year, days6, list);
            Assert.IsTrue(num == 0);
        }

        [Test]
        public async Task Test07_WorkingDays()
        {
            var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test05.txt");
            var holidays = await dataHelper.Get();
            var dayCounter = new DayCounter(holidays);

            var frDt = new DateTime(2019, 12, 31);
            var toDt = new DateTime(2020, 1, 4);
            var numWeekdays = await dayCounter.GetWorkingDays(frDt, toDt);
            Assert.IsTrue(numWeekdays == 2);

            toDt = new DateTime(2020, 2, 1);
            numWeekdays = await dayCounter.GetWorkingDays(frDt, toDt);
            Assert.IsTrue(numWeekdays == 21);

            toDt = new DateTime(2021, 1, 1);
            numWeekdays = await dayCounter.GetWorkingDays(frDt, toDt);
            Assert.IsTrue(numWeekdays == 256);

            frDt = new DateTime(2018, 12, 31);
            toDt = new DateTime(2020, 1, 1);
            numWeekdays = await dayCounter.GetWorkingDays(frDt, toDt);
            Assert.IsTrue(numWeekdays == 254);

            toDt = new DateTime(2021, 1, 1);
            numWeekdays = await dayCounter.GetWorkingDays(frDt, toDt);
            Assert.IsTrue(numWeekdays == 510);
        }

        [Test]
        public async Task Test08_WorkingDays2()
        {
            var Start = DateTime.UtcNow;
            var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test05.txt");
            var holidays = await dataHelper.Get();
            var dayCounter = new DayCounter(holidays);

            var frDt = DateTime.MinValue;
            var toDt = DateTime.MaxValue;
            var numWeekdays = await dayCounter.GetWorkingDays(frDt, toDt);
            var end = DateTime.UtcNow;

            var diff = end - Start;
            Assert.IsTrue(diff.Seconds < 1);
        }
    }
}
