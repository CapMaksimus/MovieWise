using System.ComponentModel.DataAnnotations;

namespace MovieWise.Service.MovieService;

public class CreateMovieDto
{
    [Required]
    public required string Title { get; set; }
    public string? Description { get; set; }
    [Required]
    public int ReleaseYear { get; set; }
    [Url]
    public string? PosterUrl { get; set; }
}
