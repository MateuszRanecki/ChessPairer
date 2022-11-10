using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChessPairer.Data;
using ChessPairer.Models;

namespace ChessPairer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerGroupsController : ControllerBase
    {
        private readonly ChessPairerContext _context;

        public PlayerGroupsController(ChessPairerContext context)
        {
            _context = context;
        }

        // GET: api/PlayerGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGroup>>> GetPlayerGroup()
        {
            return await _context.PlayerGroup.ToListAsync();
        }

        // GET: api/PlayerGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerGroup>> GetPlayerGroup(Guid id)
        {
            var playerGroup = await _context.PlayerGroup.FindAsync(id);

            if (playerGroup == null)
            {
                return NotFound();
            }

            return playerGroup;
        }

        // PUT: api/PlayerGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerGroup(Guid id, PlayerGroup playerGroup)
        {
            if (id != playerGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(playerGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerGroupExists(id))
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

        // POST: api/PlayerGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayerGroup>> PostPlayerGroup(PlayerGroup playerGroup)
        {
            _context.PlayerGroup.Add(playerGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayerGroup", new { id = playerGroup.Id }, playerGroup);
        }

        // DELETE: api/PlayerGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerGroup(Guid id)
        {
            var playerGroup = await _context.PlayerGroup.FindAsync(id);
            if (playerGroup == null)
            {
                return NotFound();
            }

            _context.PlayerGroup.Remove(playerGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayerGroupExists(Guid id)
        {
            return _context.PlayerGroup.Any(e => e.Id == id);
        }
    }
}
