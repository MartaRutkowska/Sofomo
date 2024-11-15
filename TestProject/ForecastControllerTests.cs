using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sofomo.Controllers;
using Sofomo.Domain.Models.Request;
using Sofomo.Domain.Models.Response;
using Sofomo.Services;

namespace TestProject
{
    public class ForecastControllerTests
    {
        private readonly ForecastController ForecastController;

        private readonly Mock<IForecastService> ForecastService;

        public ForecastControllerTests()
        {
            ForecastService = new Mock<IForecastService>();
            ForecastController = new ForecastController(ForecastService.Object);
        }

        [Fact]
        public async Task AddForecast_Returns_Ok()
        {
            ForecastService.Setup(s => s.AddCoordinates(It.IsAny<Coordinates>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var result = await ForecastController.AddForecast(new Coordinates { Latitude = 50, Longitude = 50 }, CancellationToken.None);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task AddForecast_Returns_BadRequest()
        {
            ForecastService.Setup(s => s.AddCoordinates(It.IsAny<Coordinates>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var result = await ForecastController.AddForecast(new Coordinates { Latitude = -100, Longitude = -100 }, CancellationToken.None);

            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode);
        }

        [Fact]
        public async Task Get_Returns_Ok()
        {
            var coordinates = new Coordinates { Latitude = 50, Longitude = 50 };
            var forecast = new Forecast { Coordinates = coordinates };

            ForecastService.Setup(s => s.Get(It.IsAny<Coordinates>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(forecast);

            var result = await ForecastController.Get(coordinates.Latitude.ToString(), coordinates.Longitude.ToString(), CancellationToken.None);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Get_Returns_BadRequest()
        {
            var coordinates = new Coordinates { Latitude = 50, Longitude = 50 };

            ForecastService.Setup(s => s.Get(It.IsAny<Coordinates>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Forecast?)null);

            var result = await ForecastController.Get(coordinates.Latitude.ToString(), coordinates.Longitude.ToString(), CancellationToken.None);

            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(StatusCodes.Status400BadRequest, badResult.StatusCode);
        }

        [Fact]
        public async Task Delete_Returns_NoContent()
        {
            var coordinates = new Coordinates { Latitude = 50, Longitude = 50 };

            ForecastService.Setup(s => s.DeleteCoordinatesAsync(It.IsAny<Coordinates>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var result = await ForecastController.DeleteForecast(coordinates, CancellationToken.None);

            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
        }
    }
}
