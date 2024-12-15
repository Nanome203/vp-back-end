using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TableFoodController(TableFoodService service) : ControllerBase
    {
        private readonly TableFoodService tableFoodService = service;
        [HttpGet]
        public async Task<ActionResult<List<TableFoodDTO>>> GetAllAsync()
        {
            return await tableFoodService.GetAllAsync();
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(TableFood tableFood)
        {
            var result = await tableFoodService.CreateAsync(tableFood);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await tableFoodService.DeleteAsync(id);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<int>> UpdateAsync(TableFood tableFood)
        {
            var result = await tableFoodService.UpdateAsync(tableFood);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
    }
}
