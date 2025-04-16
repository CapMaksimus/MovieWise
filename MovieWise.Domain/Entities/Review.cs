namespace MovieWise.Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public int Score { get; set; }
    public string? Commentary { get; set; }
    public required User User { get; set; }
}
