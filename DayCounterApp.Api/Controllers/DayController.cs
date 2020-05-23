using System;
using System.Threading.Tasks;
using DayCounterApp.Api.Enums;
using DayCounterApp.Api.Factories;
using DayCounterApp.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DayCounterApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DayController : ControllerBase
    {
        [HttpGet("workingdays")]
        public async Task<IActionResult> GetWorkingDays(DateTime fromDt, DateTime toDt)
        {
            try
            {
                DayCounter dayCounter = new DayCounter();
                var fr = new DateTime(2020, 5, 20, 1, 1, 1);
                var to = DateTime.Now;
                var days = dayCounter.GetWorkingDays(fr, to);
                return Ok();
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