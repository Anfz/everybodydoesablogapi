using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using everybodydoesablogapi.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using everybodydoesablogapi.Resources;

namespace everybodydoesablogapi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly BlogContext _context;
        private IUrlHelperFactory _urlHelperFactory;

        public UsersController(BlogContext context,
                               IUrlHelperFactory urlHelperFactory)
        {
            _context = context;
            _urlHelperFactory = urlHelperFactory;

        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            
            return _context.Users.ToList().Select( user =>
            {
                user = CreateLinksForUser(user);
                return user; 
            });

        }

        // GET: api/Users/5
        [HttpGet("{id}",Name = "GetUser")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(CreateLinksForUser(user));
        }

        // PUT: api/Users/5
        [HttpPut("{id}", Name = "PutUser")]
        public async Task<IActionResult> PutUser([FromRoute] Guid id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
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
        [HttpPost(Name ="PostUser"), ActionName("PostUser")]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, CreateLinksForUser(user));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        private User CreateLinksForUser(User user)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(ControllerContext);
            user.Links.Add(new Link(urlHelper.Link("GetUser", new { id = user.UserId, controller = "Users" }), "self", "GET"));
            user.Links.Add(new Link(urlHelper.Link("PutUser", new { id = user.UserId }), "update_user", "PUT"));
            user.Links.Add(new Link(urlHelper.Link("DeleteUser", new { id = user.UserId }), "delete_user", "DELETE"));  
            return user;
        }
    }
}