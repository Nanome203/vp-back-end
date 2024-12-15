using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BillController(BillService service) : ControllerBase
    {
        private readonly BillService billService = service;
        [HttpGet]
        public async Task<ActionResult<List<BillDTO>>> GetAllAsync()
        {
            return await billService.GetAllAsync();
        }
    }
}
