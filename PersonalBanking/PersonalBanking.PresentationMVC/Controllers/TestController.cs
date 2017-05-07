using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class TestController : Controller
    {

        private readonly IBankAccountRepository _bankAccountRepository;

        public TestController(IBankAccountRepository iBankAccountRepository)
        {
            _bankAccountRepository = iBankAccountRepository;
        }

        // GET: Test
        public ActionResult Index()
        {
            var test =  _bankAccountRepository.GetById(1);
            return View(test);
        }
    }
}