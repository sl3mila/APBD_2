using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }
    
    [MaxLength(100)]
    [Column("name")]
    public string ProductName { get; set; }
    
    [Column("weight")]
    public double ProductWeight { get; set; }
    
    [Column("width")]
    public double ProductWidth { get; set; }
    
    [Column("height")]
    public double ProductHeight { get; set; }
    
    [Column("depth")]
    public double ProductDepth { get; set; }
}