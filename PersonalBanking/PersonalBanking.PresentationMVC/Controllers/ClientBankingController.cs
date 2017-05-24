using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class ClientBankingController : Controller
    {
        // GET: ClientBanking
        public ActionResult Index()
        {
            return View();
        }
    }
}