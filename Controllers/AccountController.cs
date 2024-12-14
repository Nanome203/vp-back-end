using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController(AccountService service) : ControllerBase
    {
        private readonly AccountService accountService = service;
        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAllAsync()
        {
            return await accountService.GetAllAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAsync(string id)
        {
            var account = await accountService.GetAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(Account account)
        {
            var result = await accountService.CreateAsync(account);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
    }
}
