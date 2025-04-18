using System.ComponentModel.DataAnnotations;

namespace MovieWise.ViewModels.Movie;

public class CreateMovieVM
{
    [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Release year is required.")]
        [Range(1888, 2100, ErrorMessage = "Release year must be between 1888 and 2100.")]
        public int ReleaseYear { get; set; }

        [Url(ErrorMessage = "Invalid URL.")]
        public string? PosterUrl { get; set; }
}
