namespace vp_back_end.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table(nameof(Bill))]
public class Bill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public DateTime DateCheckIn { get; set; } = DateTime.Now;

    public DateTime? DateCheckOut { get; set; }

    [Required]
    public int IdTable { get; set; }

    [Required]
    public int IsServed { get; set; } = 0;

    [Required]
    public int Status { get; set; } = 0;

    [Required]
    public int Discount { get; set; } = 0;

    [Required]
    public float TotalPrice { get; set; } = 0;
    [Required]
    public int IsHidden { get; set; } = 0;

    [ForeignKey("IdTable")]
    public TableFood? TableFood { get; set; }

    public List<BillInfo> BillInfos { get; set; }
}
