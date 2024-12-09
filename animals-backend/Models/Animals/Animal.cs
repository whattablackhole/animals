namespace Animals.Models.Animals;

public abstract class Animal
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; protected set; } = string.Empty;
}