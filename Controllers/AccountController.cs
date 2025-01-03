using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.DTO;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController(AccountService service) : ControllerBase
    {
        private readonly AccountService accountService = service;



        [HttpGet("check")]
        public async Task<ActionResult> CheckExistsAsync([FromQuery] string username, [FromQuery] string password)
        {
            var result = await accountService.CheckExistsAsync(username, password);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new ValidationDTO() { IsAdmin = result.Type });
        }
        [HttpGet("type/{type}")]
        public async Task<ActionResult<List<Account>>> GetAllAsync(int type)
        {
            return await accountService.GetAllAsync(type);
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
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateAsync(string id, Account account)
        {
            var result = await accountService.UpdateAsync(id, account);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAsync(string id)
        {
            var result = await accountService.DeleteAsync(id);
            if (result == 0)
                return BadRequest();
            return NoContent();
        }
    }
}
