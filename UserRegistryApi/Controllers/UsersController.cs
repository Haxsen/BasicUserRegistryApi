using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistryApi.Models;

namespace UserRegistryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRegistryContext _context;

        public UsersController(UserRegistryContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserModel model)
        {
            var user = new User { username = model.username };
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully");
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestUsers()
        {
            var latestUsers = await _context.users
                .OrderByDescending(u => u.registered_at)
                .Take(10)
                .ToListAsync();
            return Ok(latestUsers);
        }
    }
}
