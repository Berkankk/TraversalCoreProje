using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        CommentManager commentManager = new CommentManager(new EfCommentDal());
        [HttpGet]
        public async Task<PartialViewResult> AddComment(int id)
        {
            ViewBag.destID = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = value.Id;
            ViewBag.a = "Merhaba";
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {

            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            commentManager.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
    }
}
