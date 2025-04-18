using AutoMapper;
using MovieWise.Service.MovieService;

namespace MovieWise.ViewModels.Movie;

public class MovieVMProfile : Profile
{
    public MovieVMProfile()
    {
        CreateMap<ShowMovieDto, ShowMovieVM>();
        CreateMap<CreateMovieVM, CreateMovieDto>();
    }
}
