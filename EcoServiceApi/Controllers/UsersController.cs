using EcoServiceApi.Helpers;
using EcoServiceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Post to transfer table
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/events")]
        public async Task<ActionResult> AddEvent(int userId, int eventId)
        {
            try
            {
                var user = await _context.UserDetails.FirstOrDefaultAsync(u => u.UserId == userId);

                if (user == null)
                {
                    BadRequest("User not fount");
                }

                var eventDetail = await _context.EventDetails.FirstOrDefaultAsync(u => u.EventId == eventId);

                if (eventDetail == null)
                {
                    BadRequest("Event not fount");
                }

                if (await _context.UserEventDetails.AnyAsync(e => e.UserId == userId && e.EventId == eventId))
                {
                    BadRequest();
                }

                _context.UserEventDetails.Add(new UserEventDetail { EventId = eventId, UserId = userId });
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Get user events
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/[controller]/events")]
        public async Task<ActionResult<List<EventDetail>>> GetEvents(int userId)
        {
            try
            {
                var userEvents = await _context.UserEventDetails.Where(e => e.UserId == userId).ToListAsync();

                var userEventsIds = userEvents.Select(e => e.EventId).ToList();

                var events = await _context.EventDetails.Where(e => userEventsIds.Contains(e.EventId)).ToListAsync();

                return events;

            }

            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}