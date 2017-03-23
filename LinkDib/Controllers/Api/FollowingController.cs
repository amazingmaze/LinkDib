using System.Linq;
using System.Web.Http;
using LinkDib.Dtos;
using LinkDib.Models;
using Microsoft.AspNet.Identity;

namespace LinkDib.Controllers.Api
{
    public class FollowingController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            // Check if Followee already followed
            if (_context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("User already followed.");

            // Make sure the user isnt trying to follow itself
            if (_context.Followings.Any(f => dto.FolloweeId == userId))
                return BadRequest("You cannot follow yourself.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteFollow(string id)
        {
            var userId = User.Identity.GetUserId();

            var following = _context.Followings.SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == id);

            if (following == null)
                return NotFound();

            _context.Followings.Remove(following);
            _context.SaveChanges();

            return Ok();
        }

    }
}
