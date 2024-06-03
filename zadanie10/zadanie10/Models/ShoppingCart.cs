using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie10.Models;

[Table("Shopping_Carts")]
public class ShoppingCart
{
    [Key]
    [ForeignKey("FK_account")]
    //[Column("FK_account")]
    public int ShoppingCartAccount { get; set; }
    
    [Key]
    [ForeignKey("FK_product")]
    //[Column("FK_product")]
    public int ShoppingCartProduct { get; set; }
    
    [Column("amount")]
    public int ShoppingCartAmount { get; set; }
}