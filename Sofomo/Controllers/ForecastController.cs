using Microsoft.AspNetCore.Mvc;
using Sofomo.Domain.Models.Request;
using Sofomo.Services;

namespace Sofomo.Controllers
{
    [ApiController]
    [Route("forecast")]
    public class ForecastController(
        IForecastService forecastService) : ControllerBase
    {
        private readonly IForecastService _forecastService = forecastService;

        /// <summary>
        /// Stores provided coordinates
        /// </summary>
        /// <response code="201">Coordinates saved successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Oops! Something went wrong</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddForecast([FromBody] Coordinates coordinates, CancellationToken cancellationToken)
        {
            var result = await _forecastService.AddCoordinates(coordinates, cancellationToken);
            return result ? Ok() : BadRequest("Faulty coordinates");
        }

        /// <summary>
        /// Retrieves a weather forecast for provided coordinates or returns full list if coordinates not given
        /// </summary>
        /// <response code="200">Forecast retrieved successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Oops! Something went wrong</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] string? Latitude, string? Longitude, CancellationToken cancellationToken)
        {
            if (Latitude == null || Longitude == null
                || !double.TryParse(Latitude, out var parsedLatitude)
                || !double.TryParse(Longitude, out var parsedLongitude))
            {
                return Ok(await _forecastService.GetAll(cancellationToken));
            }

            var result = await _forecastService.Get(new Coordinates { Latitude = parsedLatitude, Longitude = parsedLongitude }, cancellationToken);
            return result != null ? Ok(result) : BadRequest("No such location registered in database");
        }

        /// <summary>
        /// Removes provided coordinates
        /// </summary>
        /// <response code="204">Coordinates deleted</response>
        /// <response code="500">Oops! Something went wrong</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteForecast([FromBody] Coordinates coordinates, CancellationToken cancellationToken)
        {
            await _forecastService.DeleteCoordinatesAsync(coordinates, cancellationToken);
            return NoContent();
        }
    }
}
