using System.ComponentModel.DataAnnotations;

namespace kolokwium_1;

public class Author
{
    [Required]
    public int PK { get; set; }
    [MaxLength(50)]
    public string first_na { get; set; }
    [Required]
    [MaxLength(100)]
    public string last_na { get; set; }
}