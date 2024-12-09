namespace Animals.Core.Maps;

using Animals.Core.DTOs;
using Animals.Core.Models.Animals;
using AutoMapper;

public class AnimalProfile : Profile
{
    public AnimalProfile()
    {
        CreateMap<AnimalDto, Animal>().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}