using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie10.Models;

[Table("Products_Categories")]
public class ProductsCategory
{
    [Key]
    [Column("FK_product")]
    [ForeignKey("Product")]
    public int ProductsCategoryProduct { get; set; }
    
    public Product Product { get; set; }
    
    [Key]
    [Column("FK_category")]
    [ForeignKey("Category")]
    public int ProductsCategoryCategory { get; set; }
    
    public Category Category { get; set; }
}