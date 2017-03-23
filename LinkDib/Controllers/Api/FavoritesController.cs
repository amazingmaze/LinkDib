using System.Linq;
using System.Web.Http;
using LinkDib.Dtos;
using LinkDib.Models;
using Microsoft.AspNet.Identity;

namespace LinkDib.Controllers.Api
{
    public class FavoritesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Favorite(FavoriteDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Favorites.Any(f => f.UserId == userId && f.LinkId == dto.LinkId))
            {
                return BadRequest("Favorite already exists.");
            }

            var favorite = new Favorite
            {
                LinkId = dto.LinkId,
                UserId = userId
            };


            _context.Favorites.Add(favorite);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteFavorite(int id)
        {
            var userId = User.Identity.GetUserId();

            var favorite = _context.Favorites.SingleOrDefault(f => f.UserId == userId && f.LinkId == id);

            if (favorite == null)
                return NotFound();

            _context.Favorites.Remove(favorite);
            _context.SaveChanges();

            return Ok();
        }
    }
}