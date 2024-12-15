using System;

namespace vp_back_end.DTO;

public class FoodDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = "Chưa đặt tên";

    public int IdCategory { get; set; }

    public float Price { get; set; } = 0;
    public string ImageLink { get; set; } = "unavailable";

    public int IsHidden { get; set; } = 0;
    public string CategoryName { get; set; } = "Chưa đặt tên";

}
