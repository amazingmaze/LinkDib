using System.Linq;
using System.Web.Mvc;
using LinkDib.Models;
using LinkDib.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace LinkDib.Controllers
{
    public class LinkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinkController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new LinkFormViewModel
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LinkFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Create", viewModel);


            var link = new Link
            {
                Url = viewModel.Url,
                UserId = User.Identity.GetUserId(),
                Message = viewModel.Message,
                CategoryId = viewModel.CategoryId
            };

            _context.Links.Add(link);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult List()
        {
            var links = _context.Links
                .Include(l => l.User)
                .Include(l => l.Category);

            return View(links);
        }
    }
}