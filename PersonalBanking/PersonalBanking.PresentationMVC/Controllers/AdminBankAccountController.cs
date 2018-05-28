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
            _bankAccountService = bankAccountService;
        }

        // GET: AdminBankAccount
        public ActionResult BankAccount()
        {
          var bankAccountsDto = _bankAccountService.GetBankAccountDtos();
            var bankAccountsViewModels = AutoMapper.Mapper.Map<IList<BankAccountViewModel>>(bankAccountsDto);
            return View(bankAccountsViewModels);
        }


        public ActionResult CreateBankAccount()
        {
            return View();
        }


        public ActionResult EditBankAccount(int bankAccountId)
        {
            var bankAccountDto = _bankAccountService.GetBankAccounDtoById(bankAccountId);
            var bankAccountModel = AutoMapper.Mapper.Map<BankAccountDTO, BankAccountViewModel>(bankAccountDto);
            return View(bankAccountModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditBankAccount(BankAccountViewModel bankAccountViewModel)
        {
            
            var bankAccountDto = new BankAccountDTO();
            bankAccountDto = AutoMapper.Mapper.Map(bankAccountViewModel, bankAccountDto);
            _bankAccountService.Save(bankAccountDto);

            return View();
        }

        public ActionResult DeleteBankAccount(int bankAccountId)
        {
            var bankAccountDTO = _bankAccountService.GetBankAccounDtoById(bankAccountId);
            var bankAccountViewModel = new BankAccountViewModel();
            AutoMapper.Mapper.Map(bankAccountDTO, bankAccountViewModel);
            return View(bankAccountViewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteBankAccount(BankAccountViewModel bankAccountViewModel)
        {
            _bankAccountService.Delete(bankAccountViewModel.Id);
            return RedirectToAction("BankAccount");
        }
    }
}

