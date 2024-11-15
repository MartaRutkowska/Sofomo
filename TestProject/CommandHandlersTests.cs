using Moq;
using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Handlers.CommandHandlers;
using Sofomo.CQRS.Repositories.Shared;
using Sofomo.Domain.Models.Dtos;
using Sofomo.Domain.Models.Response;

namespace TestProject
{
    public class CommandHandlersTests
    {
        private readonly Mock<IUnitOfWork> UnitOfWork;
        private readonly AddCoordinatesCommandHandler AddCoordinatesCommandHandler;
        private readonly RemoveCoordinatesCommandHandler RemoveCoordinatesCommandHandler;
        private readonly UpdateWeatherCommandHandler UpdateWeatherCommandHandler;

        private readonly LocationDto ExistingLocation = new() { Id = 1, Latitude = 30, Longitude = 50 };

    public CommandHandlersTests()
        {
            UnitOfWork = new Mock<IUnitOfWork>();
            AddCoordinatesCommandHandler = new AddCoordinatesCommandHandler(UnitOfWork.Object);
            RemoveCoordinatesCommandHandler = new RemoveCoordinatesCommandHandler(UnitOfWork.Object);
            UpdateWeatherCommandHandler = new UpdateWeatherCommandHandler(UnitOfWork.Object);
        }

        [Fact]
        public async void AddCoordinatesCommandHandlerTest_Location_Exists()
        {
            var command = new AddCoordinatesCommand(ExistingLocation.Latitude, ExistingLocation.Longitude);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .GetByCoordinatesAsync(ExistingLocation.Latitude, ExistingLocation.Longitude))
            .ReturnsAsync(ExistingLocation);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .AddAsync(ExistingLocation))
            .Verifiable();

            UnitOfWork
            .Setup(uow => uow.Complete())
            .Verifiable();

            await AddCoordinatesCommandHandler.Handle(command, CancellationToken.None);

            UnitOfWork.Verify(uow => uow.LocationRepository.AddAsync(It.IsAny<LocationDto>()), Times.Never);
            UnitOfWork.Verify(uow => uow.Complete(), Times.Once);
        }

        [Fact]
        public async void AddCoordinatesCommandHandlerTest_Location_Not_Exists()
        {
            var command = new AddCoordinatesCommand(ExistingLocation.Latitude, ExistingLocation.Longitude);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .GetByCoordinatesAsync(ExistingLocation.Latitude, ExistingLocation.Longitude))
            .ReturnsAsync((LocationDto?)null);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .AddAsync(ExistingLocation))
            .Verifiable();

            UnitOfWork
            .Setup(uow => uow.Complete())
            .Verifiable();

            await AddCoordinatesCommandHandler.Handle(command, CancellationToken.None);

            UnitOfWork.Verify(uow => uow.LocationRepository.AddAsync(It.IsAny<LocationDto>()), Times.Once);
            UnitOfWork.Verify(uow => uow.Complete(), Times.Once);
        }

        [Fact]
        public async void UpdateWeatherCommandHandlerTest_Location_Exists()
        {
            var updatedWeather = new WeatherDto
            {
                Location = ExistingLocation,
                LocationDtoId = ExistingLocation.Id,
                Temperature = 20,
                TimeStamp = DateTimeOffset.Now,
                WindDirection = 15,
                WindSpeed = 15,

            };

            var command = new UpdateWeatherCommand(updatedWeather, ExistingLocation);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .GetByCoordinatesAsync(ExistingLocation.Latitude, ExistingLocation.Longitude))
            .ReturnsAsync(ExistingLocation);

            UnitOfWork.Setup(uow => uow.WeatherRepository
            .UpdateForCoordinates(updatedWeather, ExistingLocation.Id))
            .Verifiable();

            UnitOfWork
            .Setup(uow => uow.Complete())
            .Verifiable();

            await UpdateWeatherCommandHandler.Handle(command, CancellationToken.None);

            UnitOfWork.Verify(uow => uow.WeatherRepository.UpdateForCoordinates(It.IsAny<WeatherDto>(), It.IsAny<int>()), Times.Once);
            UnitOfWork.Verify(uow => uow.Complete(), Times.Once);
        }

        [Fact]
        public async void UpdateWeatherCommandHandlerTest_Location_Not_Exists()
        {
            var updatedWeather = new WeatherDto
            {
                Location = ExistingLocation,
                LocationDtoId = 100,
                Temperature = 20,
                TimeStamp = DateTimeOffset.Now,
                WindDirection = 15,
                WindSpeed = 15,

            };

            var command = new UpdateWeatherCommand(updatedWeather, ExistingLocation);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .GetByCoordinatesAsync(ExistingLocation.Latitude, ExistingLocation.Longitude))
            .ReturnsAsync((LocationDto?)null);

            UnitOfWork.Setup(uow => uow.WeatherRepository
            .UpdateForCoordinates(updatedWeather, ExistingLocation.Id))
            .Verifiable();

            UnitOfWork
            .Setup(uow => uow.Complete())
            .Verifiable();

            await UpdateWeatherCommandHandler.Handle(command, CancellationToken.None);

            UnitOfWork.Verify(uow => uow.WeatherRepository.UpdateForCoordinates(It.IsAny<WeatherDto>(), It.IsAny<int>()), Times.Never);
            UnitOfWork.Verify(uow => uow.Complete(), Times.Never);
        }

        [Fact]
        public async void RemoveCoordinatesCommandHandlerTest_Location_Exists()
        {
            var command = new RemoveCoordinatesCommand(ExistingLocation.Latitude, ExistingLocation.Longitude);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .GetByCoordinatesAsync(ExistingLocation.Latitude, ExistingLocation.Longitude))
            .ReturnsAsync(ExistingLocation);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .Remove(ExistingLocation))
            .Verifiable();

            UnitOfWork
            .Setup(uow => uow.Complete())
            .Verifiable();

            await RemoveCoordinatesCommandHandler.Handle(command, CancellationToken.None);

            UnitOfWork.Verify(uow => uow.LocationRepository.Remove(It.IsAny<LocationDto>()), Times.Once);
            UnitOfWork.Verify(uow => uow.Complete(), Times.Once);
        }

        [Fact]
        public async void RemoveCoordinatesCommandHandlerTest_Location_Not_Exists()
        {
            var command = new RemoveCoordinatesCommand(ExistingLocation.Latitude, ExistingLocation.Longitude);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .GetByCoordinatesAsync(ExistingLocation.Latitude, ExistingLocation.Longitude))
            .ReturnsAsync((LocationDto?)null);

            UnitOfWork.Setup(uow => uow.LocationRepository
            .Remove(ExistingLocation))
            .Verifiable();

            UnitOfWork
            .Setup(uow => uow.Complete())
            .Verifiable();

            await RemoveCoordinatesCommandHandler.Handle(command, CancellationToken.None);

            UnitOfWork.Verify(uow => uow.LocationRepository.Remove(It.IsAny<LocationDto>()), Times.Never);
            UnitOfWork.Verify(uow => uow.Complete(), Times.Once);
        }
    }
}