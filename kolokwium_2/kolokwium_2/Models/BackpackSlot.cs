using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium_2.Models;

[Table("Backpack_Slots")]
public class BackpackSlot
{
    [Key]
    [Column("PK")]
    public int BackpackSlotId { get; set; }

    [Column("FK_item")]
    [ForeignKey("Items")]
    public int BackpackSlotItem { get; set; }
    
    [Column("FK_character")]
    [ForeignKey("Characters")]
    public int BackpackSlotCharaccter { get; set; }
}