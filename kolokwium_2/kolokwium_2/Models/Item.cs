using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium_2.Models;

[Table("Items")]
public class Item
{
    [Key]
    [Column("PK")]
    public int ItemId { get; set; }
    
    [Column("name")]
    [MaxLength(50)]
    public string ItemName { get; set; }
    
    [Column("weight")]
    public int ItemWeight { get; set; }
}