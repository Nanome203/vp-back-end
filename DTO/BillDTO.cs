using System;
using vp_back_end.Models;

namespace vp_back_end.DTO;

public class BillDTO
{
    public int Id { get; set; }
    public DateTime DateCheckIn { get; set; } = DateTime.Now;
    public DateTime? DateCheckOut { get; set; }
    public int IdTable { get; set; }
    public int IsServed { get; set; } = 0;
    public int Status { get; set; } = 0;
    public int Discount { get; set; } = 0;
    public float TotalPrice { get; set; } = 0;
    // public TableFood? TableFood { get; set; }
    public int TableId { get; set; }
    public string? TableName { get; set; }
    public List<BillInfoDTO>? BillInfos { get; set; }
}
