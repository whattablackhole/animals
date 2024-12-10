using Animals.Core.DTOs;

namespace Animals.Core.Interfaces;


public interface IAnimalService
{
    Task<IEnumerable<AnimalDto>> GetAllAnimalsAsync();
    Task<AnimalDto?> GetAnimalByIdAsync(int id);
    Task<AnimalDto> CreateAnimalAsync(CreateAnimalDto animalDto);
    Task UpdateAnimalAsync(AnimalDto animalDto);
    Task DeleteAnimalAsync(int id);
}