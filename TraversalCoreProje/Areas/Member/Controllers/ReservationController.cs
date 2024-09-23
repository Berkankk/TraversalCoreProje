using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]

    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _appUserManager;

        public ReservationController(UserManager<AppUser> appUserManager)
        {
            _appUserManager = appUserManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _appUserManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByAccepted(values.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            TempData["PopupMessage"] = "Rezervasyonunuz başlangıçta onay bekliyor şeklinde alınacaktır. Rezervasyon onaylanma süreci için güncel rezervasyonlarım menüsünü takip etmeyi unutmayın.";
            var values = await _appUserManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByPrevious(values.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> ApprovalReservation()
        {
            var values = await _appUserManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByWaitApproval(values.Id);
            return View(valuesList);
        }


        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString(),
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            TempData["PopupMessage"] = "Rezervasyonunuz başlangıçta onay bekliyor şeklinde alınacaktır. Rezervasyon onaylanma süreci için güncel rezervasyonlarım menüsünü takip etmeyi unutmayın.";
            p.AppUserID = 3;
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
        public IActionResult Deneme()
        {
            return View();
        }
    }
}
