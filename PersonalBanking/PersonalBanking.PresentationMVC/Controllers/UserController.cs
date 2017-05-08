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
                var user = new UserViewModel();
                user.Username = model.Username;
                user.Person.FirstName = model.Person.FirstName;
                user.Person.LastName = model.Person.LastName;
                user.Person.BirthDate = model.Person.BirthDate;
                user.Person.Gender = model.Person.Gender;
                user.Person.FiscalCode = model.Person.FiscalCode;

                user.Email = model.Email;
                user.Password = model.Password;
                user.ConfirmPassword = model.ConfirmPassword;
                
            }
            return View(model);
        }
    }
}