using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public HomeController(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }


        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Name = "test";

            var bankacc = _bankAccountRepository.GetById(1);
            return View(bankacc);
        }
    }
}