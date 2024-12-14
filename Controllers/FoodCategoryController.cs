using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.DTO;
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
    }
}
