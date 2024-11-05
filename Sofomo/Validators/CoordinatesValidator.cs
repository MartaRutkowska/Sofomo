using FluentValidation;
using Sofomo.Helpers;
using Sofomo.Models.Request;
using static Sofomo.Helpers.Constants;

namespace Sofomo.Validators
{
    public class CoordinatesValidator : AbstractValidator<Coordinates>
    {
        public CoordinatesValidator()
        {
            RuleFor(x => x.Latitude >= MinLatitude && x.Latitude <= MaxLatitude);
            RuleFor(x => x.Longitude >= MinLongtitude && x.Longitude <= MaxLongtitude);
        }
    }
}
