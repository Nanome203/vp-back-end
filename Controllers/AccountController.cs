using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vp_back_end.Models;
using vp_back_end.Services;

namespace vp_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(AccountService service) : ControllerBase
    {
        private readonly AccountService accountService = service;
        [HttpGet]
        public async Task<ActionResult<List<Account>>> Get()
        {
            return await accountService.GetAll();
        }
    }
}
