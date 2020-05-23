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
        [HttpGet("holidays")]
        public async Task<IActionResult> GetHolidays()
        {
            var dataHelper = DataHelperFactory<IHoliday>.GetDataHelper((int)DataSourceTypeEn.CSV);
            var dataSet = await dataHelper.Get();
            
            
            return Ok(dataSet);
        }
    }
}