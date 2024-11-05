using Microsoft.AspNetCore.Mvc;
using Sofomo.Domain.Models.Request;
using Sofomo.Services;

namespace Sofomo.Controllers
{
    [ApiController]
    [Route("forecast")]
    public class ForecastController(
        ForecastService forecastService) : ControllerBase
    {
        private readonly ForecastService _forecastService = forecastService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] Coordinates coordinates)
        {
            if (coordinates == null)
            {
                return Ok(await _forecastService.GetAll());
            }

            var result = await _forecastService.Get(coordinates);
            return result != null ? Ok(result) : BadRequest("No such location registered in database");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddForecast([FromBody] Coordinates coordinates)
        {
            var result = await _forecastService.AddCoordinates(coordinates);
            return result ? Ok() : BadRequest("Faulty coordinates");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteForecast([FromBody] Coordinates coordinates)
        {
            await _forecastService.DeleteCoordinatesAsync(coordinates);
            return NoContent();
        }
    }
}
