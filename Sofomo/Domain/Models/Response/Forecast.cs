using Sofomo.Domain.Models.Request;

namespace Sofomo.Domain.Models.Response
{
    public class Forecast
    {
        public required Coordinates Coordinates { get; set; }

        public Weather? Weather { get; set; }
    }
}
