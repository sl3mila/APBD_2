using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie10.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Key]
    [Column("FK_account")]
    [ForeignKey("Account")]
    public int ShoppingCartAccount { get; set; }
    
    public Account Account { get; set; }
    
    [Key]
    [Column("FK_product")]
    [ForeignKey("Product")]
    public int ShoppingCartProduct { get; set; }
    
    public Product Product { get; set; }
    
    [Column("amount")]
    public int ShoppingCartAmount { get; set; }
}