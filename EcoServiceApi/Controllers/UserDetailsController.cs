using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoServiceApi.Models;
using EcoServiceApi.Helpers;

namespace EcoServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly EcoServiceContext _context;

        public UserDetailsController(EcoServiceContext context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
            return await _context.UserDetails.ToListAsync();
        }

        // GET: api/UserDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);


            if (userDetail == null)
            {
                return NotFound();
            }
            userDetail.Password = "";

            return userDetail;
        }

        // PUT: api/UserDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetail(int id, UserDetail userDetail)
        {
            if (id != userDetail.UserId)
            {
                return BadRequest();
            }

            userDetail.Email = userDetail.Email.ToLower().Trim();
            if (!string.IsNullOrEmpty(userDetail.Password))
            {
                userDetail.Password = PasswordEncryptor.Encrypt(userDetail.Password);
            }

            _context.Entry(userDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDetails
        [HttpPost]
        public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail userDetail)
        {
            userDetail.Email = userDetail.Email.ToLower().Trim();

            if (!string.IsNullOrEmpty(userDetail.Password))
            {
                userDetail.Password = PasswordEncryptor.Encrypt(userDetail.Password);
            }

            if(await _context.UserDetails.AnyAsync(u => u.Email == userDetail.Email))
            {
                return BadRequest($"User with {userDetail.Email} already exist.");
            }

            _context.UserDetails.Add(userDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserDetail", new { id = userDetail.UserId }, userDetail);
        }

        // DELETE: api/UserDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDetail>> DeleteUserDetail(int id)
        {
            var userDetail = await _context.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return NotFound();
            }

            _context.UserDetails.Remove(userDetail);
            await _context.SaveChangesAsync();

            return userDetail;
        }

        private bool UserDetailExists(int id)
        {
            return _context.UserDetails.Any(e => e.UserId == id);
        }
    }
}
