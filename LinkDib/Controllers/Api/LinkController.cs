using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinkDib.Models;
using Microsoft.AspNet.Identity;

namespace LinkDib.Controllers.Api
{
    [Authorize]
    public class LinkController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public LinkController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var link = _context.Links.Single(l => l.Id == id && l.UserId == userId);
            link.IsDeleted = true;
            _context.SaveChanges();

            return Ok();

        }
    }
}
