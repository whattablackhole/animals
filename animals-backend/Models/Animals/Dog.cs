namespace Animals.Models.Animals;

public class Dog : Animal
{
    public Dog()
    {
        Type = "dog";
    }

    public void Bark()
    {
        Console.WriteLine($"{Name} says Woof!");
    }
}