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
    public class NewsDetailsController : ControllerBase
    {
        private readonly EcoServiceContext _context;

        public NewsDetailsController(EcoServiceContext context)
        {
            _context = context;
        }

        // GET: api/NewsDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDetail>>> GetNewsDetails()
        {
            return await _context.NewsDetails.ToListAsync();
        }

        // GET: api/NewsDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDetail>> GetNewsDetail(int id)
        {
            var newsDetail = await _context.NewsDetails.FindAsync(id);

            if (newsDetail == null)
            {
                return NotFound();
            }

            return newsDetail;
        }

        // PUT: api/NewsDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewsDetail(int id, NewsDetail newsDetail)
        {
            if (id != newsDetail.NewsId)
            {
                return BadRequest();
            }

            _context.Entry(newsDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsDetailExists(id))
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

        // POST: api/NewsDetails
        [HttpPost]
        public async Task<ActionResult<NewsDetail>> PostNewsDetail(NewsDetail newsDetail)
        {
            _context.NewsDetails.Add(newsDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewsDetail", new { id = newsDetail.NewsId }, newsDetail);
        }

        // DELETE: api/NewsDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsDetail>> DeleteNewsDetail(int id)
        {
            var newsDetail = await _context.NewsDetails.FindAsync(id);
            if (newsDetail == null)
            {
                return NotFound();
            }

            _context.NewsDetails.Remove(newsDetail);
            await _context.SaveChangesAsync();

            return newsDetail;
        }

        private bool NewsDetailExists(int id)
        {
            return _context.NewsDetails.Any(e => e.NewsId == id);
        }
    }
}
