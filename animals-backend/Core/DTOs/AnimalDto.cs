namespace Animals.Core.DTOs;

public class AnimalDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
}