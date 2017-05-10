using PersonalBanking.PresentationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            var user = new UserViewModel();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {

                return View("Thanks", model);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }
    }
}