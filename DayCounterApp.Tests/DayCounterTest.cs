using DayCounterApp.Api.Interfaces;
using DayCounterApp.Api.Models;
using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Factories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
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
            //var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test01.txt");
            //var holidays = await dataHelper.Get();
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
        public void Test04_IsHolidayFixedWeekdayInWeekdays()
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
        public async Task Test99_WorkingDaysAsync()
        {
            var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test05.txt");
            var holidays = await dataHelper.Get();
            var dayCounter = new DayCounter(holidays);

            var frDt = new DateTime(2020, 1, 1);
            var toDt = new DateTime(2020, 1, 4);
            var result = dayCounter.GetWorkingDays(frDt, toDt);
        }
    }
}
