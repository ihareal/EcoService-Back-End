﻿using EcoServiceApi.Helpers;
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

        [HttpPost]
        [Route("api/[controller]/login")]
        public async Task<ActionResult<UserDetail>> Login([FromBody]string email, [FromBody]string password)
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

        [HttpPost]
        [Route("api/[controller]/events")]
        public async Task<ActionResult> AddEvent([FromBody] int userId, [FromBody] int eventId)
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

            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/events")]
        public async Task<ActionResult<List<int>>> GetEvents(int userId)
        {
            try
            {
                var userEvents = await _context.UserEventDetails.Where(e => e.UserId == userId).ToListAsync();

                return userEvents.Select(e => e.EventId).ToList();
                
            }

            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}