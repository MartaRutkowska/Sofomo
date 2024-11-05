using Sofomo.Handlers.CommandHandler;
using Sofomo.Handlers.CommandHandlers;
using Sofomo.Handlers.QueryHandlers;

namespace Sofomo.Handlers
{
    public static class ServicExtenstions
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AddCoordinatesCommandHandler>();
            services.AddTransient<GetAllLocationsQueryHandler>();
            services.AddTransient<GetLocationQueryHandler>();
            services.AddTransient<GetWeatherQueryHandler>();
            services.AddTransient<DeleteCoordinatesCommandHandler>();
            services.AddTransient<UpdateWeatherCommandHandler>();
        }
    }
}
