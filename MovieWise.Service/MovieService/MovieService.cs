// Реализация MovieService
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieWise.Data.MovieRepository;
using MovieWise.Domain.Entities;

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

    public async Task<int> CreateMovieAsync(CreateMovieDto movieDto)
    {
        try
        {
            var movie = _mapper.Map<Movie>(movieDto);
            var createdMovie = await _movieRepository.AddMovieAsync(movie);
            return createdMovie.Id;
        }
        catch (AutoMapperMappingException ex)
        {
            // Логирование ошибок маппинга
            Console.WriteLine($"Mapping error: {ex.Message}");
            throw new ArgumentException("Invalid movie data", ex);
        }
        catch (DbUpdateException ex)
        {
            // Логирование ошибок БД
            Console.WriteLine($"Database error: {ex.Message}");
            throw new ApplicationException("Error saving movie", ex);
        }
        catch (Exception ex)
        {
            // Общее логирование
            Console.WriteLine($"Unexpected error: {ex.Message}");
            throw;
        }

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