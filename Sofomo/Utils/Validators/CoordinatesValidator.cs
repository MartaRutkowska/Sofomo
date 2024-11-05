using FluentValidation;
using Sofomo.Domain.Models.Request;
using static Sofomo.Utils.Helpers.Constants;

namespace Sofomo.Utils.Validators
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
