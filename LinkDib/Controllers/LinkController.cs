using System.Linq;
using System.Web.Mvc;
using LinkDib.Models;
using LinkDib.ViewModels;
using Microsoft.AspNet.Identity;

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
            var viewModel = new LinkFormViewModel();

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
                Message = new LinkMessage(viewModel.Message)
            };

            _context.Links.Add(link);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}