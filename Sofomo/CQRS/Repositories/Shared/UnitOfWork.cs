namespace Sofomo.CQRS.Repositories.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext DatabaseContext;

        public IWeatherRepository WeatherRepository { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            DatabaseContext = context;
            WeatherRepository = new WeatherRepository(DatabaseContext);
            LocationRepository = new LocationRepository(DatabaseContext);
        }

        public async Task<int> Complete() => await DatabaseContext.SaveChangesAsync();

        public async void Dispose() => await DatabaseContext.DisposeAsync();
    }
}
