namespace Sofomo.CQRS.Repositories.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IWeatherRepository WeatherRepository { get; }
        ILocationRepository LocationRepository { get; }
        Task<int> Complete();
    }
}
