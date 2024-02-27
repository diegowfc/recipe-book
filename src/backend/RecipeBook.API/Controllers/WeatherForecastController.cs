using Microsoft.AspNetCore.Mvc;
using RecipeBook.Application.UseCases.User.Register;
using RecipeBook.Communication.Request;
using RecipeBook.Exceptions;

namespace RecipeBook.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> GetAsync()
        {
            var usecase = new UseCaseRegisterUser();
            await usecase.Register(new UserRegistrationRequestJSON //Just for test now
            {

            });
            return Ok();
        }
    }
}