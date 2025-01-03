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

        [HttpPatch("{id}/checkout")]
        public async Task<ActionResult> PayBillAsync(int id)
        {
            var result = await billService.PayBillAsync(id);
            return result != 0 ? Ok(await GetAsync(id)) : BadRequest();
        }

        [HttpPatch("{id}/edit")]
        public async Task<ActionResult> EditBillAsync(BillEditDTO billEdit, int id)
        {
            var result = await billService.EditBillAsync(billEdit, id);
            return result != 0 ? NoContent() : BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(BillDTO billDTO)
        {
            var result = await billService.CreateAsync(billDTO);
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<List<BillDTO>>> GetAllAsync()
        {
            return await billService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BillDTO>> GetAsync(int id)
        {
            var billDTO = await billService.GetAsync(id);
            if (billDTO == null)
            {
                return NotFound();
            }
            return billDTO;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await billService.DeleteAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
