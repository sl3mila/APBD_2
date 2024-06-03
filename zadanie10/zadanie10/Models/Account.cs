using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace zadanie10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountId { get; set; }
    //public int AccountRole { get; set; }
    
    [MaxLength(50)]
    [Column("first_name")]
    public string AccountFirstName { get; set; }
    
    [MaxLength(50)]
    [Column("last_name")]
    public string AccountLastName { get; set; }
    
    [MaxLength(80)]
    [Column("email")]
    public string AccountEMail { get; set; }
    
    //[Nullable()] ??
    [MaxLength(9)]
    [Column("phone")]
    public string AccountPhone { get; set; }
}