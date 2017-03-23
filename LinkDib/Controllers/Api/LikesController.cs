using System.Linq;
using System.Web.Http;
using LinkDib.Dtos;
using LinkDib.Models;
using Microsoft.AspNet.Identity;

namespace LinkDib.Controllers.Api
{
    public class LikesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public LikesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Like(LikeDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Likes.Any(l => l.UserId == userId && l.LinkId == dto.LinkId))
                return BadRequest("Like already exists.");

            var like = new Like
            {
                UserId = userId,
                LinkId = dto.LinkId
            };

            _context.Likes.Add(like);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteLike(int id)
        {
            var userId = User.Identity.GetUserId();

            var like = _context.Likes.SingleOrDefault(l => l.UserId == userId && l.LinkId == id);

            if (like == null)
                return NotFound();

            _context.Likes.Remove(like);
            _context.SaveChanges();

            return Ok();
        }

    }
}
