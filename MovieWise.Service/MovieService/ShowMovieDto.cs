namespace MovieWise.Service.MovieService;

public class ShowMovieDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
    public string? PosterUrl { get; set; }
    public required List<string> Genres { get; set; } = new();
}
