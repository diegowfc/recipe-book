using Microsoft.AspNetCore.Mvc;
using RecipeBook.Exceptions;

namespace RecipeBook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var message = ExceptionMessages.EmptyInputName;
            return Ok();
        }
    }
}