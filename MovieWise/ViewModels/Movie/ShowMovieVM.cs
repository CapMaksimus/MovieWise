namespace MovieWise.ViewModels.Movie;

public class ShowMovieVM
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
    public string? PosterUrl { get; set; }
    
    // Исходный список жанров (можно оставить, если нужен для чего-то)
    public List<string> Genres { get; set; } = new();
    
    // Жанры в виде строки
    public string GenresList => Genres.Any() 
        ? string.Join(", ", Genres) 
        : "Жанры не указаны";
}
