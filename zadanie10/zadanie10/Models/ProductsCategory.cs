using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie10.Models;

[Table("Products_Categories")]
public class ProductsCategory
{
    [Key]
    [ForeignKey("FK_product")]
    public int ProductsCategoryProduct { get; set; }
    
    [Key]
    [ForeignKey("FK_category")]
    public int ProductsCategoryCategory { get; set; }
}