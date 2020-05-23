using DayCounterApp.Api.Interfaces;
using DayCounterApp.Api.Models;
using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Factories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DayCounterApp.Tests.Helpers
{
    class CsvHelperHolidayTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test01_InvalidData()
        {
            try 
            {
                var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test01.txt");
                var holidays = await dataHelper.Get();

                Assert.Fail();
            }
            catch (AssertionException)
            {
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task Test02_InvalidData()
        {
            try
            {
                var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test02.txt");
                var holidays = await dataHelper.Get();

                Assert.Fail();
            }
            catch (AssertionException)
            {
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task Test03_InvalidData()
        {
            try
            {
                var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test03.txt");
                var holidays = await dataHelper.Get();

                Assert.Fail();
            }
            catch (AssertionException)
            {
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task Test04_InvalidData()
        {
            try
            {
                var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test04.txt");
                var holidays = await dataHelper.Get();

                Assert.Fail();
            }
            catch (AssertionException)
            {
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task Test05()
        {
            var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv, "holiday_test05.txt");
            var holidays = await dataHelper.Get();

            Assert.IsTrue(holidays.Count() == 7);

            for (int i = 0; i < holidays.Count(); i++)
            {
                var holiday = holidays.ElementAt(i);

                if (i == 0)
                {
                    var h = holiday as HolidayAdditionalDate;
                    Assert.IsTrue(h.Id == 1);
                    Assert.IsTrue(h.Name.Equals("New Year"));
                    Assert.IsTrue(h.Type == (int)HolidayTypeEn.AdditionalDate);
                    Assert.IsTrue(h.Month == 1);
                    Assert.IsTrue(h.Day == 1);
                }
                else if (i == 1)
                {
                    var h = holiday as HolidayAdditionalDate;
                    Assert.IsTrue(h.Id == 2);
                    Assert.IsTrue(h.Name.Equals("Australian Day"));
                    Assert.IsTrue(h.Type == (int)HolidayTypeEn.AdditionalDate);
                    Assert.IsTrue(h.Month == 1);
                    Assert.IsTrue(h.Day == 26);
                }
                else if (i == 2)
                {
                    var h = holiday as Holiday;
                    Assert.IsTrue(h.Id == 3);
                    Assert.IsTrue(h.Name.Equals("Anzac Day"));
                    Assert.IsTrue(h.Type == (int)HolidayTypeEn.FixedDate);
                    Assert.IsTrue(h.Month == 4);
                    Assert.IsTrue(h.Day == 25);
                }
                else if (i == 3)
                {
                    var h = holiday as HolidayFixedWeekday;
                    Assert.IsTrue(h.Id == 4);
                    Assert.IsTrue(h.Name.Equals("Queen's Birthday"));
                    Assert.IsTrue(h.Type == (int)HolidayTypeEn.FixedWeekday);
                    Assert.IsTrue(h.Month == 6);
                    Assert.IsTrue(h.Week == 2);
                    Assert.IsTrue(h.DayOfWeek == (int)DayOfWeek.Monday);
                }
                else if (i == 4)
                {
                    var h = holiday as HolidayFixedWeekday;
                    Assert.IsTrue(h.Id == 5);
                    Assert.IsTrue(h.Name.Equals("Labour Day"));
                    Assert.IsTrue(h.Type == (int)HolidayTypeEn.FixedWeekday);
                    Assert.IsTrue(h.Month == 10);
                    Assert.IsTrue(h.Week == 1);
                    Assert.IsTrue(h.DayOfWeek == (int)DayOfWeek.Monday);
                }
                else if (i == 5)
                {
                    var h = holiday as HolidayAdditionalDate;
                    Assert.IsTrue(h.Id == 6);
                    Assert.IsTrue(h.Name.Equals("Christmas Day"));
                    Assert.IsTrue(h.Type == (int)HolidayTypeEn.AdditionalDate);
                    Assert.IsTrue(h.Month == 12);
                    Assert.IsTrue(h.Day == 25);
                }
                else if (i == 6)
                {
                    var h = holiday as HolidayAdditionalDate;
                    Assert.IsTrue(h.Id == 7);
                    Assert.IsTrue(h.Name.Equals("Boxing Day"));
                    Assert.IsTrue(h.Type == (int)HolidayTypeEn.AdditionalDate);
                    Assert.IsTrue(h.Month == 12);
                    Assert.IsTrue(h.Day == 26);
                }
            }
        }
    }
}
