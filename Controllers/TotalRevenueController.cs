using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TotalRevenueController(TotalRevenueService service) : ControllerBase
    {
        private readonly TotalRevenueService totalRevenueService = service;

        [HttpGet]
        public async Task<float> GetMonthAsync(int month, int year)
        {
            return await totalRevenueService.GetMonthAsync(month, year);
        }
        [HttpGet("{year}")]
        public async Task<float> GetYearAsync(int year)
        {
            return await totalRevenueService.GetYearAsync(year);
        }
    }
}
