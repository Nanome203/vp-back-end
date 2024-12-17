using Microsoft.AspNetCore.Mvc;
using vp_back_end.DTO;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodController(FoodService service) : ControllerBase
    {
        private readonly FoodService foodService = service;
        [HttpGet]
        public async Task<ActionResult<List<FoodDTO>>> GetAllAsync()
        {
            var list = await foodService.GetAllAsync();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }

        [HttpGet("popularity")]
        public async Task<ActionResult<List<FoodCountDTO>>> GetFoodPopularityAsync()
        {
            var list = await foodService.GetFoodPopularityAsync();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return list;
        }
        [HttpPost]
        public async Task<ActionResult> CreateAsync(FoodDTO foodDTO)
        {
            var results = await foodService.CreateAsync(foodDTO);
            if (results == 0)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, FoodDTO foodDTO)
        {
            if (id != foodDTO.Id)
            {
                return BadRequest();
            }
            var result = await foodService.UpdateAsync(foodDTO);
            Console.WriteLine(result);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await foodService.DeleteAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
