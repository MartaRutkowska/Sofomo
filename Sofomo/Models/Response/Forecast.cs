using Sofomo.Models.Request;

namespace Sofomo.Models.Response
{
    public class Forecast
    {
        public required Coordinates Coordinates { get; set; }

        public Weather? Weather { get; set; }
    }
}
