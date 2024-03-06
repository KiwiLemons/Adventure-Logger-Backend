using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureLoggerBackend.Data;
using AdventureLoggerBackend.Models;

namespace AdventureLoggerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly AdventureLoggerBackendContext _context;

        public FriendsController(AdventureLoggerBackendContext context)
        {
            _context = context;
        }

        // GET: api/Friends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend>>> GetFollows()
        {
            return await _context.Friends.ToListAsync();
        }

        // GET: api/Friends/5
        //Add a follow from user with id [from] and to user with id [to]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> AddFollow(int from, int to)
        {
            var user = await _context.User.FindAsync(from);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Friends
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.user_id }, user);
        }

        // DELETE: api/Friends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.user_id == id);
        }
    }
}
