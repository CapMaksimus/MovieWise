using AutoMapper;
using MovieWise.Domain.Entities;

namespace MovieWise.Service.MovieService;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, ShowMovieDto>()
            .ForMember(dest => dest.Genres, 
                opt => opt.MapFrom(src => src.Genres.Select(g => g.Name)));
    }
}