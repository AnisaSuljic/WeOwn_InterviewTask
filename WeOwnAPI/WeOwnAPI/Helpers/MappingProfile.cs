using AutoMapper;
using WeOwnAPI.DTOs;
using WeOwnAPI.ValueObjects;
using WeOwnDomain.Database;

namespace WeOwnAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieAndTvShow, MovieAndTvShowDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => new Typee(src.Type)))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => new Description(src.Description)))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new Rating(src.Rating)));

            CreateMap<MovieAndTvShowDTO, MovieAndTvShow>();

            CreateMap<MovieAndTvShowInsertDTO, MovieAndTvShow>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.ToString()));
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Value))
                //.ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.Value));
        }
    }
}
