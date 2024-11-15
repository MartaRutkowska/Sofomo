using Sofomo.CQRS.Handlers.CommandHandlers;
using Sofomo.CQRS.Handlers.QueryHandlers;

namespace Sofomo.CQRS.Handlers
{
    public static class ServicExtenstions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AddCoordinatesCommandHandler>();
            services.AddTransient<GetAllLocationsQueryHandler>();
            services.AddTransient<GetLocationQueryHandler>();
            services.AddTransient<GetWeatherQueryHandler>();
            services.AddTransient<RemoveCoordinatesCommandHandler>();
            services.AddTransient<UpdateWeatherCommandHandler>();
        }
    }
}
