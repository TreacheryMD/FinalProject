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
    public class ClientBankingController : Controller
    {
        private readonly IClientBankingService _bankingService;
        private readonly ITransferManagerService _transferManagerService;
        

        public ClientBankingController(IClientBankingService bankingService, ITransferManagerService transferManagerService)
        {
            _bankingService = bankingService;
            _transferManagerService = transferManagerService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CurrentBankAccounts()
        {

            var currentAccountsDto = _bankingService.GetCurrentAccountDtos(Convert.ToInt32(Session["UserId"]));
            var currentAccountsVm = AutoMapper.Mapper.Map<IList<CurrentAccountDTO>, IList<CurrentAccountViewModel>>(currentAccountsDto);

            return View(currentAccountsVm);
        }

        public ActionResult Transfer()
        {
            var currentAccountsDto = _bankingService.GetCurrentAccountDtos(Convert.ToInt32(Session["UserId"]));
            var currentAccountsVm = AutoMapper.Mapper.Map<IList<CurrentAccountDTO>, IList<CurrentAccountViewModel>>(currentAccountsDto);

            return View(currentAccountsVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfer(TransferingViewModel transactionViewModel)
        {
            _transferManagerService.ExecuteTransfer(transactionViewModel.SourceBankAccountNumber,transactionViewModel.TargetBankAccountNumber,transactionViewModel.Ammount);
            return RedirectToAction("Index");
        }

    }
}