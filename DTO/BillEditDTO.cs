using System;

namespace vp_back_end.DTO;

public class BillEditDTO
{
    public float TotalPrice { get; set; }
    public List<BillInfoEditDTO> editList { get; set; }
}
