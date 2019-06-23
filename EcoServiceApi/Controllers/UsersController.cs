using EcoServiceApi.Helpers;
using EcoServiceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcoServiceApi.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly EcoServiceContext _context;

        public UsersController(EcoServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]/login")]
        public async Task<ActionResult<UserDetail>> Login(string email, string password)
        {
            var user =  await _context.UserDetails.FirstOrDefaultAsync(u => u.Email.Equals(email.Trim()));

            if (user == null)
            {
                return BadRequest($"User with {email} not found.");
            }

            string passwordHash = PasswordEncryptor.Encrypt(password);

            if (user.Password != passwordHash)
            {
                return BadRequest($"Password isn't correct.");
            }

            user.Password = "";

            return user;
        }
    }
}