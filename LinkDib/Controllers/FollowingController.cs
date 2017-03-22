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

    }
}
