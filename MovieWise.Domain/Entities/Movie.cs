using System;

namespace MovieWise.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public int ReleaseYear { get; set; }
    public string? PosterUrl { get; set; }
    public required List<Genre> Genres { get; set; } = new();
    public required List<Review> Reviews { get; set; } = new();
}
