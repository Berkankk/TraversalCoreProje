using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    public class CommnetController : Controller
    {
        [Area("Member")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
