using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium_2.Models;

[Table("Characters_Titles")]
public class CharactersTitle
{
    [Key]
    [Column("FK_charact")]
    [ForeignKey("Characters")]
    public int CharacterTitleCharacter { get; set; }
    
    [Key]
    [Column("FK_title")]
    [ForeignKey("Titles")]
    public int CharacterTitleTitle { get; set; }
    
    [Column("aquire_at")]
    public DateTime CharacterTitleAquireAt { get; set; }
}