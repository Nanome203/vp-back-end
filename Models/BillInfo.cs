
namespace vp_back_end.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table(nameof(BillInfo))]
public class BillInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int IdBill { get; set; }

    [Required]
    public int IdFood { get; set; }

    [Required]
    public int Count { get; set; } = 0;

    [ForeignKey("IdBill")]
    public Bill? Bill { get; set; }

    [ForeignKey("IdFood")]
    public Food? Food { get; set; }
}

