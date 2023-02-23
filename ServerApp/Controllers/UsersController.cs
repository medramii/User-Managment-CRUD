using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DBContext _context;

        public UsersController(DBContext context) => _context = context;

        [HttpGet("getUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        [HttpGet("getUser/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var User = await _context.User.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User User)
        {
            if (id != User.idUser)
            {
                return BadRequest();
            }

            _context.Entry(User).State = EntityState.Modified;

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

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User User)
        {
            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = User.idUser }, User);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = await _context.User.FindAsync(id);
            if (User == null)
            {
                return NotFound();
            }

            _context.User.Remove(User);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(u => u.idUser == id);
        }


    }
}
