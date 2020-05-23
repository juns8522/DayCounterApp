using DayCounterApp.Api.Factories;
using DayCounterApp.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DayCounterApp.Api.Helpers
{
    public class CsvHelperHoliday : CsvHelper<IHoliday>
    {
        public string FilePath{ private get; set; }
        public char Separator { get; private set; }

        public CsvHelperHoliday()
        {
            FilePath = "holiday.txt";
            Separator = ',';
        }

        public CsvHelperHoliday(string filePath)
        {
            FilePath = filePath;
            Separator = ',';
        }

        public override Task<IHoliday> Add(IHoliday holiday)
        {
            throw new NotImplementedException();
        }

        public override Task Delete()
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<IHoliday>> Get()
        {
            var items = new List<IHoliday>();

            using (var reader = new StreamReader(FilePath))
            {
                while (true)
                {
                    string line = await reader.ReadLineAsync();
                    if (line == null)
                        break;

                    string[] arr = line.Split(Separator);
                    items.Add(HolidayFactory.GetHoliday(arr));
                }
            }
            return items;
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
