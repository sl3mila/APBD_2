using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium_2.Models;

[Table("Characters")]
public class Character
{
    [Key]
    [Column("PK")]
    public int CharacterId { get; set; }
    
    [MaxLength(50)]
    [Column("first_name")]
    public string CharacterFirstName { get; set; }
    
    [MaxLength(50)]
    [Column("last_name")]
    public string CharacterLastName { get; set; }
    
    [Column("current_weight")]
    public int CharacterCurrentWeight { get; set; }
    
    [Column("max_weight")]
    public int CharacterMaxWeihght { get; set; }
    
    [Column("money")]
    public int CharacterMoney { get; set; }
    
    //[MaxLenghth(50)]
    //[ForeignKey("NazwaTabeliZKtórejJestKlucz")
    
    //public IEnumerable<NazwaInnejTabeli> NazwaInnejTabeliWliczbieMnogiej { get; set; }
    
}