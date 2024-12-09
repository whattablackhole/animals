namespace Animals.Core.Models.Animals;

public class Cat : Animal
{
    public Cat() : base("cat")
    {
    }
    public void Meow()
    {
        Console.WriteLine($"{Name} says Meow!");
    }
}