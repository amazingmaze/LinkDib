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

    }
}
