using ClanXMember.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClanXMember.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanController : ControllerBase
    {
        
        private readonly DataContext _context;
        public ClanController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Clan>>> GetClans()
        {
            return Ok(await _context.Clans.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Clan>> GetClanById(int? id)
        {
            if(id==null)
            {
                return BadRequest("id is null!");
            }
            var clan = await _context.Clans.FindAsync(id);
            if(clan== null)
            {
                return NotFound("Clan not found!");
            }
            return Ok(clan);
        }

        [HttpPost]
        public async Task<ActionResult<Clan>> CreateClan(Clan? clan)
        {
            if(clan == null)
            {
                return BadRequest("Clan is null!");
            }
            _context.Clans.Add(clan);
            await _context.SaveChangesAsync();
            return Ok(clan);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Clan>> UpdateClan(int? id, Clan? clan)
        {
            if(id == null || clan == null)
            {
                return BadRequest("id or clan is null!");
            }
            var updatedClan = await _context.Clans.FindAsync(id);
            if(updatedClan==null)
            {
                return NotFound("This clan not found");
            }
            updatedClan.Name = clan.Name;
            updatedClan.Capacity = clan.Capacity;
            await _context.SaveChangesAsync();
            return Ok(updatedClan);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Clan>> DeleteClan(int? id)
        {
            if(id==null)
            {
                return BadRequest("id is null!");
            }
            var deletedClan = await _context.Clans.FindAsync(id);
            if(deletedClan==null)
            {
                return NotFound("Clan to be deleted is not found!");
            }
            _context.Clans.Remove(deletedClan);
            await _context.SaveChangesAsync();
            return Ok(deletedClan);
        }

        
    }
}
