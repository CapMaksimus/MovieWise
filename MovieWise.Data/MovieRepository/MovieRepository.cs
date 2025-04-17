using Microsoft.EntityFrameworkCore;
using MovieWise.Domain.Entities;

namespace MovieWise.Data.MovieRepository;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _dbContext;

    public MovieRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _dbContext.Movies
            .Include(m => m.Genres) // Включаем связанные жанры
            .AsNoTracking() // Для read-only операций
            .ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genreName)
    {
        return await _dbContext.Movies
            .Where(m => m.Genres.Any(g => g.Name == genreName))
            .Include(m => m.Genres)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetMoviesByYearAsync(int year)
    {
        return await _dbContext.Movies
            .Where(m => m.ReleaseYear == year)
            .Include(m => m.Genres)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Movie?> GetMovieByIdAsync(int id)
    {
        return await _dbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie> AddMovieAsync(Movie movie)
    {
        await _dbContext.Movies.AddAsync(movie);
        await _dbContext.SaveChangesAsync();
        return movie;
    }

    public async Task UpdateMovieAsync(Movie movie)
    {
        _dbContext.Entry(movie).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteMovieAsync(int id)
    {
        var movie = await _dbContext.Movies.FindAsync(id);
        if (movie != null)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
