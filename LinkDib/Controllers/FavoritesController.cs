using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkDib.Dtos;
using LinkDib.Models;
using Microsoft.AspNet.Identity;

namespace LinkDib.Controllers
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
    }
}