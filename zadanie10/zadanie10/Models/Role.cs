using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie10.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int RoleId { get; set; }
    
    [MaxLength(100)]
    [Column("name")]
    public string RoleName { get; set; }
}