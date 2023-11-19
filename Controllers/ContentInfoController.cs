using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using draftAPI.Context;
using draftAPI.Model;

namespace draftAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentInfoController : ControllerBase
    {
        private readonly DraftContext _context;

        public ContentInfoController(DraftContext context)
        {
            _context = context;
        }

        // GET: api/ContentInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContentInfo>>> GetContents()
        {
            return await _context.Contents.ToListAsync();
        }

        // GET: api/ContentInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContentInfo>> GetContentInfo(Guid id)
        {
            var contentInfo = await _context.Contents.FindAsync(id);

            if (contentInfo == null)
            {
                return NotFound();
            }

            return contentInfo;
        }

        // PUT: api/ContentInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContentInfo(Guid id, ContentInfo contentInfo)
        {
            if (id != contentInfo.ContentId)
            {
                return BadRequest();
            }

            _context.Entry(contentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentInfoExists(id))
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

        // POST: api/ContentInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContentInfo>> PostContentInfo(ContentInfo contentInfo)
        {
            _context.Contents.Add(contentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContentInfo", new { id = contentInfo.ContentId }, contentInfo);
        }

        // DELETE: api/ContentInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentInfo(Guid id)
        {
            var contentInfo = await _context.Contents.FindAsync(id);
            if (contentInfo == null)
            {
                return NotFound();
            }

            _context.Contents.Remove(contentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentInfoExists(Guid id)
        {
            return _context.Contents.Any(e => e.ContentId == id);
        }
    }
}
