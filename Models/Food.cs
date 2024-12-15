
namespace vp_back_end.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table(nameof(Food))]
public class Food
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column(TypeName = "nvarchar")]
    public string Name { get; set; } = "Chưa đặt tên";

    [Required]
    public int IdCategory { get; set; }

    [Required]
    public float Price { get; set; } = 0;
    [MaxLength(255)]
    public string ImageLink { get; set; } = "unavailable";

    [Required]
    public int IsHidden { get; set; } = 0;

    [ForeignKey("IdCategory")]
    public FoodCategory? FoodCategory { get; set; }
}
