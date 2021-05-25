using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingAppWebAPI.DBModels;
using System.Collections.Generic;
using BankingAppWebAPI.Services.Interfaces;

namespace BankingAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _usersService.GetUsers());
        }
    }
}
