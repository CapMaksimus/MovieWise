using MovieWise.Domain.Entities;

namespace MovieWise.Data.Repositories.Interfaces;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genreName);
    Task<IEnumerable<Movie>> GetMoviesByYearAsync(int year);
    Task<Movie?> GetMovieByIdAsync(int id);
    Task<Movie> AddMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(int id);
}
