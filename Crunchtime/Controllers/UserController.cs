using Microsoft.AspNetCore.Mvc;
using Crunchtime.Repositiories;
using Crunchtime.Entities;

namespace Crunchtime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
    public UserController(IUserService userService)
        {
            _userService = userService;
        }
    [HttpPost]
    public async Task<IActionResult> CreateUser(User newUser)
    {
        var userDetails = await _userService.CreateUser(newUser);
        return Ok(userDetails);
    }
    }
}
