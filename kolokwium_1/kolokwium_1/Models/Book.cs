using System.ComponentModel.DataAnnotations;

namespace kolokwium_1;

public class Book
{
    /* przykład
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [MaxLength(200)]
    public string Descriptiopn { get; set; } //kategoria; nullable
    */
    public static int idCount = 0;
    
    [Required]
    public int PK { get; set; }
    [Required]
    [MaxLength(100)]
    public string title { get; set; }
}