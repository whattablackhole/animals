using Animals.Core.DTOs;
using Animals.Core.Interfaces;
using Animals.Core.Models.Animals;
using AutoMapper;

public interface IAnimalMapper
{
    AnimalDto ToDto(Animal animal);
    Animal ToEntity(AnimalDto animalDto);
    Animal ToEntity(AnimalDto animalDto, Animal animal);
}

public class AnimalMapper : IAnimalMapper
{
    private readonly IAnimalFactory _animalFactory;
    private readonly IMapper _mapper;
    public AnimalMapper(IAnimalFactory animalFactory, IMapper mapper
)
    {
        _mapper = mapper;
        _animalFactory = animalFactory;
    }

    public AnimalDto ToDto(Animal animal)
    {
        return new AnimalDto { Id = animal.Id, Name = animal.Name, Type = animal.Type };
    }

    public Animal ToEntity(AnimalDto animalDto)
    {
        var animal = _animalFactory.CreateAnimal(animalDto.Type);
        _mapper.Map(animalDto, animal);

        return animal;
    }

     public Animal ToEntity(AnimalDto animalDto, Animal animal)
    {
        var newAnimal = _animalFactory.CreateAnimal(animalDto.Type);

        _mapper.Map(animal, newAnimal);
        _mapper.Map(animalDto, newAnimal);

        return newAnimal;
    }
}