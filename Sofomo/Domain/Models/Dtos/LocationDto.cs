using System.ComponentModel.DataAnnotations;

namespace Sofomo.Domain.Models.Dtos
{
    public class LocationDto
    {
        [Key]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public WeatherDto? Weather { get; set; }
    }
}
