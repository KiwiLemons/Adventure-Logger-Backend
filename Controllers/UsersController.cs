﻿using System;
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
    public class UsersController : ControllerBase
    {
        private readonly AdventureLoggerBackendContext _context;

        public UsersController(AdventureLoggerBackendContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{id}/following")]
        public async Task<ActionResult<IEnumerable<UserDisplay>>> GetFollowing(int id)
        {
            //Get a list of IDs that user [id] follows
            var friends = _context.Friend.Where(f => f.from == id).Select(f => f.to).ToList();

            return await _context.User.Where(u => friends.Contains(u.user_id)).Select(u => new UserDisplay {user_id = u.user_id, UserName = u.UserName, profile_picture = u.profile_picture}).ToListAsync();
        }

        [HttpGet("{id}/followers")]
        public async Task<ActionResult<IEnumerable<UserDisplay>>> GetFollowers(int id)
        {
            //Get a list of followers IDs for user [id]
            var friends = _context.Friend.Where(f => f.to == id).Select(f => f.from).ToList();

            return await _context.User.Where(u => friends.Contains(u.user_id)).Select(u => new UserDisplay { user_id = u.user_id, UserName = u.UserName, profile_picture = u.profile_picture }).ToListAsync();
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.user_id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.user_id }, user);
        }

        // DELETE: api/Users/5
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
