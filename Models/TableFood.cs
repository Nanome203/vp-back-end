namespace vp_back_end.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table(nameof(TableFood))]
public class TableFood
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column(TypeName = "nvarchar")]
    public string Name { get; set; } = "Chưa đặt tên";

    [Required]
    [MaxLength(100)]
    [Column(TypeName = "nvarchar")]
    public string Status { get; set; } = "Chưa hoạt động";

    [Required]
    public int IsHidden { get; set; } = 0;
}

