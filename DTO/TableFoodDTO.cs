namespace vp_back_end.DTO;

public class TableFoodDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = "Chưa đặt tên";
    public string Status { get; set; } = "Trống";
    public int UnpaidBillId { get; set; }
}

