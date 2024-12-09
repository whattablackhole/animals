namespace Animals.Core.Models.Animals;

public class Dog : Animal
{
    public Dog() : base("dog")
    {
    }

    public void Bark()
    {
        Console.WriteLine($"{Name} says Woof!");
    }
}