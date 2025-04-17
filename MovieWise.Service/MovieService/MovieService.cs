// Реализация MovieService
using AutoMapper;
using MovieWise.Data.MovieRepository;

namespace MovieWise.Service.MovieService;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieService(
        IMovieRepository movieRepository,
        IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ShowMovieDto>> GetAllMoviesAsync()
    {
        try
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return _mapper.Map<IEnumerable<ShowMovieDto>>(movies);
        }
        catch (Exception ex)
        {
            // Логирование ошибки
            Console.WriteLine($"Error retrieving movies: {ex.Message}");
            return new List<ShowMovieDto>();
        }
    }
}