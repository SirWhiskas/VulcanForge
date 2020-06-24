using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VulcanForge.Models;

namespace VulcanForge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceTypesController : ControllerBase
    {
        private readonly VulcanForgeContext _context;

        public ResourceTypesController(VulcanForgeContext context)
        {
            _context = context;
        }

        // GET: api/ResourceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceType>>> GetResourceType()
        {
            return await _context.ResourceType.ToListAsync();
        }

        // GET: api/ResourceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceType>> GetResourceType(long id)
        {
            var resourceType = await _context.ResourceType.FindAsync(id);

            if (resourceType == null)
            {
                return NotFound();
            }

            return resourceType;
        }

        // PUT: api/ResourceTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResourceType(long id, ResourceType resourceType)
        {
            if (id != resourceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(resourceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResourceTypeExists(id))
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

        // POST: api/ResourceTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ResourceType>> PostResourceType(ResourceType resourceType)
        {
            _context.ResourceType.Add(resourceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResourceType", new { id = resourceType.Id }, resourceType);
        }

        // DELETE: api/ResourceTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResourceType>> DeleteResourceType(long id)
        {
            var resourceType = await _context.ResourceType.FindAsync(id);
            if (resourceType == null)
            {
                return NotFound();
            }

            _context.ResourceType.Remove(resourceType);
            await _context.SaveChangesAsync();

            return resourceType;
        }

        private bool ResourceTypeExists(long id)
        {
            return _context.ResourceType.Any(e => e.Id == id);
        }
    }
}
