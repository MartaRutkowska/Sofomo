using AutoMapper;
using Sofomo.Models.Dtos;
using Sofomo.Models.Request;
using Sofomo.Models.Response;

namespace Sofomo.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherDto, Weather>()
                .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
                .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.WindSpeed))
                .ForMember(dest => dest.WindDirection, opt => opt.MapFrom(src => src.WindDirection));

            CreateMap<LocationDto, Coordinates>()
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude));
        }
    }
}
