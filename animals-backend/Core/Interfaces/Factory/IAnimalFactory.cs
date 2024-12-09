using Animals.Core.Models.Animals;

namespace Animals.Core.Interfaces;
public interface IAnimalFactory
{
    Animal CreateAnimal(string type);
}