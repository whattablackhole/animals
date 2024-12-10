using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animals.Core.Models.Animals;

public abstract class Animal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; protected set; } = string.Empty;

    protected Animal(string type)
    {
        Type = type;
    }
}