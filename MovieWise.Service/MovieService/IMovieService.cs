namespace MovieWise.Service.MovieService;

public interface IMovieService
{
    Task<IEnumerable<ShowMovieDto>> GetAllMoviesAsync();
}
