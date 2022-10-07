using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UsersController : BaseApiController  //inherting from baseapicontroller
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        // IEnumerable or List can be used here but keep it simple with IEnum //
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // api/users/3
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}