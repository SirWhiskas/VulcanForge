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
    [Route("api/CampaignSettings")]
    [ApiController]
    public class CampaignSettingsController : ControllerBase
    {
        private readonly VulcanForgeContext _context;

        public CampaignSettingsController(VulcanForgeContext context)
        {
            _context = context;
        }

        // GET: api/CampaignSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaignSettingDTO>>> GetCampaignSettings()
        {
            return await _context.CampaignSetting.Select(x => ItemToDTO(x)).ToListAsync();
        }

        // GET: api/CampaignSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignSettingDTO>> GetCampaignSetting(long id)
        {
            var CampaignSetting = await _context.CampaignSetting.FindAsync(id);

            if (CampaignSetting == null) 
            {
                return NotFound();
            }

            return ItemToDTO(CampaignSetting);
        }

        // PUT: api/CampaignSetting/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaignSetting(CampaignSettingDTO CampaignSettingDTO)
        {
            var CampaignSetting = await _context.CampaignSetting.FindAsync(CampaignSettingDTO.Id);
            if (CampaignSetting == null)
            {
                return NotFound();
            }

            CampaignSetting.Name = CampaignSettingDTO.Name;
            CampaignSetting.WorldId = CampaignSetting.WorldId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CampaignSettingExists(CampaignSettingDTO.Id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/CampaignSetting
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CampaignSetting>> PostCampaignSetting(CampaignSettingDTO CampaignSettingDTO)
        {
            var CampaignSetting = new CampaignSetting
            {
                Name = CampaignSettingDTO.Name,
                WorldId = CampaignSettingDTO.WorldId
            };

            _context.CampaignSetting.Add(CampaignSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCampaignSetting), new { id = CampaignSetting.Id }, ItemToDTO(CampaignSetting));
        }

        // DELETE: api/CampaignSetting/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CampaignSetting>> DeleteCampaignSetting(long id)
        {
            var CampaignSetting = await _context.CampaignSetting.FindAsync(id);
            if (CampaignSetting == null)
            {
                return NotFound();
            }

            _context.CampaignSetting.Remove(CampaignSetting);
            await _context.SaveChangesAsync();

            return CampaignSetting;
        }

        private bool CampaignSettingExists(long id)
        {
            return _context.CampaignSetting.Any(e => e.Id == id);
        }

        private static CampaignSettingDTO ItemToDTO(CampaignSetting CampaignSetting) =>
            new CampaignSettingDTO
            {
                Id = CampaignSetting.Id,
                WorldId = CampaignSetting.WorldId,
                Name = CampaignSetting.Name
            };
    }
}
