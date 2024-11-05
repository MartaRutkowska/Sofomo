using Sofomo.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sofomo.Models.Dtos
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
