namespace MovieWise.Service.MovieService;

public interface IMovieService
{
    Task<IEnumerable<ShowMovieDto>> GetAllMoviesAsync();
    Task<int> CreateMovieAsync(CreateMovieDto movieDto);
}
