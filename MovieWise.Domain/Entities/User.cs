namespace MovieWise.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Login { get; set; }
    public required string HashedPassword { get; set; }
}
