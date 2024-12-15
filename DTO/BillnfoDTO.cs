using vp_back_end.Models;

namespace vp_back_end.DTO;

public class BillInfoDTO
{
    public int Id { get; set; }
    public int IdFood { get; set; }
    public string? FoodName { get; set;}
    public int Count { get; set; } = 0;
}
