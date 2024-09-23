using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel viewModel)
        {
            var valueSender = _accountService.TGetById(viewModel.SenderID);
            var valueReceiver = _accountService.TGetById(viewModel.ReceiverID);

            valueSender.Balance -= viewModel.Amount;
            valueReceiver.Balance += viewModel.Amount;

            List<Account> modifiedAccount = new List<Account>()
            {
                valueSender,
                valueReceiver
            };

            _accountService.TMultiUpdate(modifiedAccount);
            return View();
        }
    }
}
