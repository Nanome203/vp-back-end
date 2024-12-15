using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("food/categories")]
    [ApiController]
    public class FoodCategoryController(FoodCategoryService service) : ControllerBase
    {
        private readonly FoodCategoryService fcService = service;
        [HttpGet]
        public async Task<ActionResult<List<FoodCategoryDTO>>> GetAllAsync()
        {
            var list = await fcService.GetAllAsync();
            if (list.Count == 0)
                return NotFound();
            return Ok(list);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(FoodCategory service)
        {
            var result = await fcService.CreateAsync(service);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(int id)
        {
            var result = await fcService.DeleteAsync(id);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<int>> UpdateAsync(FoodCategory foodCategory)
        {
            var result = await fcService.UpdateAsync(foodCategory);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
    }
}
