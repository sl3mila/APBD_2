using System.ComponentModel.DataAnnotations;

namespace zadanie5;

public class Animal
{
    [Required]
    public int IdAnimal { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Descriptiopn { get; set; } //kategoria; nullable
    [Required]
    [MaxLength(200)]
    public string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public string Area { get; set; }
}