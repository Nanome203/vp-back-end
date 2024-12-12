namespace vp_back_end.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table(nameof(FoodCategory))]
public class FoodCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column(TypeName = "nvarchar")]
    public string Name { get; set; } = "Chưa đặt tên";

    [Required]
    public int IsHidden { get; set; } = 0;
}

