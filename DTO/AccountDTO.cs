
using System;

namespace vp_back_end.DTO;
public class AccountDTO
{
    public string? UserName { get; set; }
    public string DisplayName { get; set; } = "Admin";

    public string PassWord { get; set; } = "0";
    public int Type { get; set; } = 0;
}
