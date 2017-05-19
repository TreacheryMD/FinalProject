using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.PresentationMVC.Models;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class AdminBankAccountController : Controller
    {
        private readonly IBankAccountService _bankAccountService;

        public AdminBankAccountController(IBankAccountService bankAccountService)
        {
           // _bankAccountService = bankAccountService;
        }

        // GET: AdminBankAccount
        public ActionResult BankAccount()
        {
          //  var bankAccountsDto = _bankAccountService.GetBankAccountDtos();
            return View();
        }
    }
}