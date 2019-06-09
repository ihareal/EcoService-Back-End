using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcoServiceApi.Models;

namespace EcoServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollutionDetailsController : ControllerBase
    {
        private readonly EcoServiceContext _context;

        public PollutionDetailsController(EcoServiceContext context)
        {
            _context = context;
        }

        // GET: api/PollutionDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PollutionDetail>>> GetPollutionDetails()
        {
            return await _context.PollutionDetails.ToListAsync();
        }

        // GET: api/PollutionDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PollutionDetail>> GetPollutionDetail(int id)
        {
            var pollutionDetail = await _context.PollutionDetails.FindAsync(id);

            if (pollutionDetail == null)
            {
                return NotFound();
            }

            return pollutionDetail;
        }

        // PUT: api/PollutionDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPollutionDetail(int id, PollutionDetail pollutionDetail)
        {
            if (id != pollutionDetail.PollutionId)
            {
                return BadRequest();
            }

            _context.Entry(pollutionDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollutionDetailExists(id))
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

        // POST: api/PollutionDetails
        [HttpPost]
        public async Task<ActionResult<PollutionDetail>> PostPollutionDetail(PollutionDetail pollutionDetail)
        {
            _context.PollutionDetails.Add(pollutionDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPollutionDetail", new { id = pollutionDetail.PollutionId }, pollutionDetail);
        }

        // DELETE: api/PollutionDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PollutionDetail>> DeletePollutionDetail(int id)
        {
            var pollutionDetail = await _context.PollutionDetails.FindAsync(id);
            if (pollutionDetail == null)
            {
                return NotFound();
            }

            _context.PollutionDetails.Remove(pollutionDetail);
            await _context.SaveChangesAsync();

            return pollutionDetail;
        }

        private bool PollutionDetailExists(int id)
        {
            return _context.PollutionDetails.Any(e => e.PollutionId == id);
        }
    }
}
