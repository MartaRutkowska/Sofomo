using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sofomo.Models.Dtos
{
    public class WeatherDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double Temperature { get; set; }
        public double WindDirection { get; set; }
        public double WindSpeed { get; set; }

        public DateTimeOffset TimeStamp { get; set; }


        public int LocationDtoId { get; set; }
        public LocationDto Location { get; set; }
    }
}
