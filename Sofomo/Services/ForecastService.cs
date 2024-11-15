using AutoMapper;
using MediatR;
using Sofomo.CQRS.Commands;
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
        IMediator mediator) : IForecastService
    {
        private readonly ExternalMeteoService _externalService = externalService;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator mediator = mediator;

        public async Task<Forecast?> Get(Coordinates coordinates, CancellationToken cancellationToken)
        {
            var getLocationQuery = new GetLocationQuery(coordinates.Latitude, coordinates.Longitude);
            var locationDto = await mediator.Send(getLocationQuery, cancellationToken);

            if (locationDto == null) return null;

            var weather = await _externalService.Get(coordinates);
            if (weather != null)
            {
                return await CreateForecastFromMeteo(coordinates, locationDto, weather, cancellationToken);
            }

            return await CreateResponseFromDatabase(coordinates, cancellationToken);
        }

        private async Task<Forecast?> CreateResponseFromDatabase(Coordinates coordinates, CancellationToken cancellationToken)
        {
            var weatherQuery = new GetWeatherQuery(coordinates.Latitude, coordinates.Longitude);
            var lastSavedWeather = await mediator.Send(weatherQuery, cancellationToken);

            return new Forecast
            {
                Coordinates = coordinates,
                Weather = _mapper.Map<Weather>(lastSavedWeather)
            };
        }

        private async Task<Forecast> CreateForecastFromMeteo(Coordinates coordinates, LocationDto? locationDto, Weather weather, CancellationToken cancellationToken)
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
            await mediator.Send(command, cancellationToken);

            return new Forecast
            {
                Coordinates = coordinates,
                Weather = weather
            };
        }

        public async Task<List<Forecast?>> GetAll(CancellationToken cancellationToken)
        {
            var command = new GetAllLocationsQuery();
            var locations = await mediator.Send(command, cancellationToken);

            var result = new List<Forecast?>();
            foreach (var location in locations)
            {
                result.Add(
                    await Get(
                        _mapper.Map<Coordinates>(location), cancellationToken));
            }

            return result;
        }

        public async Task<bool> AddCoordinates(Coordinates coordinates, CancellationToken cancellationToken)
        {
            if (!new CoordinatesValidator().Validate(coordinates).IsValid) return false;

            var command = new AddCoordinatesCommand(coordinates.Latitude, coordinates.Longitude);
            await mediator.Send(command, cancellationToken);
            return true;
        }

        public async Task DeleteCoordinatesAsync(Coordinates coordinates, CancellationToken cancellationToken)
        {
            var command = new RemoveCoordinatesCommand(coordinates.Latitude, coordinates.Longitude);
            await mediator.Send(command, cancellationToken);
        }
    }
}
