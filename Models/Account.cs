
namespace vp_back_end.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table(nameof(Account))]
public class Account
{
    [Key]
    [Column(TypeName = "nvarchar(100)")]
    public string? UserName { get; set; }

    [Required]
    [MaxLength(100)]
    [Column(TypeName = "nvarchar")]
    public string DisplayName { get; set; } = "Admin";

    [Required]
    [MaxLength(1000)]
    [Column(TypeName = "nvarchar")]
    public string PassWord { get; set; } = "0";

    [Required]
    public int Type { get; set; } = 0;
}
