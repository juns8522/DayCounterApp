using System;
using System.Globalization;
using System.Threading.Tasks;
using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Factories;
using DayCounterApp.Api.Interfaces;
using DayCounterApp.Api.Models.AppSettings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DayCounterApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DayController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("workingdays")]
        public async Task<IActionResult> GetWorkingDays(string from, string to)
        {
            try
            {
                var dataSource = new DataSource();
                _configuration.GetSection("DataSource").Bind(dataSource);

                string pattern = "yyyy-MM-dd";
                var fromDt = DateTime.ParseExact(from, pattern, null, DateTimeStyles.None);
                var toDt = DateTime.ParseExact(to, pattern, null, DateTimeStyles.None);

                var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper(dataSource);
                var holidays = await dataHelper.Get();
                var dayCounter = new DayCounter(holidays);
                
                var days = await dayCounter.GetWorkingDays(fromDt, toDt);
                return Ok(days);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("holidays")]
        public async Task<IActionResult> GetHolidays()
        {
            try
            {
                var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.Csv);
                var dataSet = await dataHelper.Get();
                return Ok(dataSet);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}