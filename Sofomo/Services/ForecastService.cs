using AutoMapper;
using Sofomo.CQRS.Commands;
using Sofomo.CQRS.Handlers.CommandHandlers;
using Sofomo.CQRS.Handlers.QueryHandlers;
using Sofomo.CQRS.Queries;
using Sofomo.Domain.Models.Dtos;
using Sofomo.Domain.Models.Request;
using Sofomo.Domain.Models.Response;
using Sofomo.Utils.Validators;

namespace Sofomo.Services
{
    public class ForecastService(
        ExternalMeteoService externalService,
        IMapper mapper,
        AddCoordinatesCommandHandler addCoordinatesCommandHandler,
        DeleteCoordinatesCommandHandler deleteCoordinatesCommandHandler,
        UpdateWeatherCommandHandler updateWeatherCommandHandler,
        GetAllLocationsQueryHandler getAllLocationsQueryHandler,
        GetLocationQueryHandler getLocationQueryHandler,
        GetWeatherQueryHandler getWeatherQueryHandler)
    {
        private readonly ExternalMeteoService _externalService = externalService;
        private readonly IMapper _mapper = mapper;
        private readonly AddCoordinatesCommandHandler _addCoordinatesCommandHandler = addCoordinatesCommandHandler;
        private readonly DeleteCoordinatesCommandHandler _deleteCoordinatesCommandHandler = deleteCoordinatesCommandHandler;
        private readonly UpdateWeatherCommandHandler _updateWeatherCommandHandler = updateWeatherCommandHandler;
        private readonly GetAllLocationsQueryHandler _getallLocationsQueryHandler = getAllLocationsQueryHandler;
        private readonly GetLocationQueryHandler _getLocationQueryHandler = getLocationQueryHandler;
        private readonly GetWeatherQueryHandler _getWeatherQueryHandler = getWeatherQueryHandler;

        public async Task<Forecast?> Get(Coordinates coordinates)
        {
            var getLocationQuery = new GetLocationQuery(coordinates.Latitude, coordinates.Longitude);
            var locationDto = await _getLocationQueryHandler.HandleAsync(getLocationQuery);

            if (locationDto == null) return null;

            var weather = await _externalService.Get(coordinates);
            if (weather != null)
            {
                return await CreateForecastFromMeteo(coordinates, locationDto, weather);
            }

            return await CreateResponseFromDatabase(coordinates);
        }

        private async Task<Forecast?> CreateResponseFromDatabase(Coordinates coordinates)
        {
            var weatherQuery = new GetWeatherQuery(coordinates.Latitude, coordinates.Longitude);
            var lastSavedWeather = await _getWeatherQueryHandler.HandleAsync(weatherQuery);
            return new Forecast
            {
                Coordinates = coordinates,
                Weather = _mapper.Map<Weather>(lastSavedWeather)
            };
        }

        private async Task<Forecast> CreateForecastFromMeteo(Coordinates coordinates, LocationDto? locationDto, Weather weather)
        {
            if (locationDto == null) return new Forecast { Coordinates = coordinates };

            var updatedWeather = new WeatherDto
            {
                Location = locationDto,
                LocationDtoId = locationDto.Id,
                Temperature = weather.Temperature,
                TimeStamp = DateTimeOffset.Now,
                WindDirection = weather.WindDirection,
                WindSpeed = weather.WindSpeed,

            };
            var command = new UpdateWeatherCommand(updatedWeather, locationDto);
            await _updateWeatherCommandHandler.HandleAsync(command);

            return new Forecast
            {
                Coordinates = coordinates,
                Weather = weather
            };
        }

        public async Task<List<Forecast?>> GetAll()
        {
            var command = new GetAllLocationsQuery();
            var locations = await _getallLocationsQueryHandler.HandleAsync(command);

            var result = new List<Forecast?>();
            foreach (var location in locations)
            {
                result.Add(
                    await Get(
                        _mapper.Map<Coordinates>(location)));
            }

            return result;
        }

        public async Task<bool> AddCoordinates(Coordinates coordinates)
        {
            if (!new CoordinatesValidator().Validate(coordinates).IsValid) return false;

            var command = new AddCoordinatesCommand(coordinates.Latitude, coordinates.Longitude);
            await _addCoordinatesCommandHandler.HandleAsync(command);
            return true;
        }

        public async Task DeleteCoordinatesAsync(Coordinates coordinates)
        {
            var command = new DeleteCoordinatesCommand(coordinates.Latitude, coordinates.Longitude);
            await _deleteCoordinatesCommandHandler.HandleAsync(command);
        }
    }
}
