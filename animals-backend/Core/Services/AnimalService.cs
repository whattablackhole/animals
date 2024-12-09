namespace Animals.Core.Services;

using Animals.Core.DTOs;
using Animals.Core.Interfaces;
using Animals.Core.Models.Animals;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;

    private readonly IAnimalMapper _animalMapper;
    public AnimalService(IAnimalRepository animalRepository, IAnimalMapper mapper)
    {
        _animalRepository = animalRepository;
        _animalMapper = mapper;
    }

    public async Task<IEnumerable<AnimalDto>> GetAllAnimalsAsync()
    {
        var animals = await _animalRepository.GetAllAsync();
        return animals.Select(a => new AnimalDto { Id = a.Id, Name = a.Name, Type = a.Type });
    }

    public async Task<AnimalDto?> GetAnimalByIdAsync(int id)
    {
        var animal = await _animalRepository.GetByIdAsync(id);
        return animal != null ? new AnimalDto { Id = animal.Id, Name = animal.Name, Type = animal.Type } : null;
    }

    public async Task<AnimalDto> CreateAnimalAsync(AnimalDto animalDto)
    {
        var animal = _animalMapper.ToEntity(animalDto);

        await _animalRepository.AddAsync(animal);

        await _animalRepository.SaveChangesAsync();

        return _animalMapper.ToDto(animal);
    }

    public async Task UpdateAnimalAsync(AnimalDto animalDto)
    {
        var animal = await _animalRepository.GetByIdAsync(animalDto.Id);

        if (animal != null)
        {
            var updatedAnimal = _animalMapper.ToEntity(animalDto, animal);

            _animalRepository.Update(updatedAnimal);

            await _animalRepository.SaveChangesAsync();
        } else {
            throw new KeyNotFoundException($"Animal with ID {animalDto.Id} not found.");
        }
    }

    public async Task DeleteAnimalAsync(int id)
    {
        await _animalRepository.DeleteAsync(id);
        await _animalRepository.SaveChangesAsync();
    }
}