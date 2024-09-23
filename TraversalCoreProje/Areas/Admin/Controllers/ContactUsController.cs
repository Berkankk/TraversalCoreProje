using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TGetList();
            return View(values);
        }
        public IActionResult DeleteContactUs(int id)
        {
            var values = _contactUsService.TGetByID(id);
            _contactUsService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
