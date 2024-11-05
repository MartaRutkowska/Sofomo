using Sofomo.Models.Dtos;
using Sofomo.Queries.Shared;

namespace Sofomo.Queries
{
    public record GetLocationQuery(double Latitude, double Longitude) : IQuery<LocationDto>;

}
