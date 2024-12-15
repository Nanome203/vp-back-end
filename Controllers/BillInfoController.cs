using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("Bill_Info")]
    [ApiController]
    public class BillInfoController(BillInfoService service) : ControllerBase
    {
        private readonly BillInfoService biService = service;
        // [HttpGet("{IdBill}")]
        // public async Task<ActionResult<List<BillInfoDTO>>> GetAllAsync(int IdTableFood, int IdBill)
        // {
        //     var list = await biService.GetAllAsync(IdTableFood, IdBill);
        //     if (list.Count == 0)
        //         return NotFound();
        //     return Ok(list);
        // }

        // [HttpPost]
        // public async Task<ActionResult<int>> CreateAsync(BillInfo service)
        // {
        //     var result = await biService.CreateAsync(service);
        //     if (result == 0)
        //         return BadRequest();
        //     return NoContent();
        // }

        // [HttpPut]
        // public async Task<ActionResult<int>> UpdateAsync(BillInfo billInfo)
        // {
        //     var result = await biService.UpdateAsync(billInfo);
        //     if (result == 0)
        //         return BadRequest();
        //     return NoContent();
        // }

        // [HttpDelete("{id}")]
        // public async Task<ActionResult<int>> DeleteAsync(int id)
        // {
        //     var result = await biService.DeleteAsync(id);
        //     if (result == 0)
        //         return BadRequest();
        //     return NoContent();
        // }
    }
}
