using System.ComponentModel.DataAnnotations;

namespace kolokwium_1;

public class Genre
{
    [Required]
    public int PK { get; set; }
    [Required]
    [MaxLength(100)]
    public string nam { get; set; }
}