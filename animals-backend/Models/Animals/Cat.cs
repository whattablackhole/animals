namespace Animals.Models.Animals;

public class Cat : Animal
{
    public Cat()
    {
        Type = "cat";
    }
    public void Meow()
    {
        Console.WriteLine($"{Name} says Meow!");
    }
}