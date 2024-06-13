using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium_2.Models;

[Table("nazwaTabeli")]
public class ExampleTableClass
{
    [Key]
    [Column("nazwaKolumny")]
    public int NazwaTabeliId { get; set; }
    
    //[MaxLenghth(50)]
    //[ForeignKey("NazwaTabeliZKtórejJestKlucz")
    
    //public IEnumerable<NazwaInnejTabeli> NazwaInnejTabeliWliczbieMnogiej { get; set; }
    
}