using Animals.Core.Interfaces;
using Animals.Core.Models.Animals;

namespace Animals.Core.Factories;


public class AnimalFactory : IAnimalFactory
{
    public Animal CreateAnimal(string type)
    {
        return type.ToLower() switch
        {
            "cat" => new Cat(),
            "dog" => new Dog(),
            _ => throw new ArgumentException("Invalid animal type")
        };
    }
}