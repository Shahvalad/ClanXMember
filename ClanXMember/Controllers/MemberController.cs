using ClanXMember.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClanXMember.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly DataContext _context;
        public MemberController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            return Ok(await _context.Members.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMemberById(int? id)
        {
            if (id == null)
            {
                return BadRequest("id is null!");
            }
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound("Member is not found");
            }
            return Ok(member);
        }
        [HttpPost]
        public async Task<ActionResult<Member>> CreateMember(Member? member)
        {
            if (member == null)
            {
                return BadRequest("Member is null!");
            }
            var clan = await _context.Clans.FindAsync(member.ClanId);
            if(clan == null)
            {
                return BadRequest("There is no such clan");
            }
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return Ok(member);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Member>> UpdateMember(int? id, Member? member)
        {
            if (id == null || member==null )
            {
                return BadRequest("Id or member is null!");
            }
            var updatedMember = await _context.Members.FindAsync(id);
            if (updatedMember == null)
            {
                return NotFound("updatedMember is not found!");
            }
            updatedMember.Name = member.Name;
            updatedMember.Surname = member.Surname;
            updatedMember.Age = member.Age;
            updatedMember.ClanId = member.ClanId;
            await _context.SaveChangesAsync();
            return Ok(updatedMember);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(int? id)
        {
            if (id == null)
            {
                return BadRequest("id is null!");
            }
            var deletedMember = await _context.Members.FindAsync(id);
            if (deletedMember == null)
            {
                return NotFound("Clan to be deleted is not found!");
            }
            _context.Members.Remove(deletedMember);
            await _context.SaveChangesAsync();
            return Ok(deletedMember);
        }
    }
}
