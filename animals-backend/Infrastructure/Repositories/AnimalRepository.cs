namespace Animals.Repositories;

using Animals.Core.Models.Animals;
using Animals.Core.Interfaces;
using Animals.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AnimalRepository : IAnimalRepository
{
    private readonly AnimalsDbContext _context;

    public AnimalRepository(AnimalsDbContext context) => _context = context;

    public async Task<IEnumerable<Animal>> GetAllAsync()
        => await _context.Animals.ToListAsync();

    public async Task<Animal?> GetByIdAsync(int id)
        => await _context.Animals.FindAsync(id);

    public async Task AddAsync(Animal entity)
        => await _context.Animals.AddAsync(entity);

    public async Task DeleteAsync(int id)
    {
        var animal = await _context.Animals.FindAsync(id);
        if (animal != null)
        {
            _context.Animals.Remove(animal);
        }
    }

    public void Update(Animal animal)
    {
        _context.Animals.Update(animal);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}