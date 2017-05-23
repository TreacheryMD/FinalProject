using PersonalBanking.BLL.Services;
using PersonalBanking.PresentationMVC.Models;
using PersonalBanking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Register
        public ActionResult Register()
        {
            var user = new CreateUserViewModel();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pers = new PersonDTO()
                {
                    BirthDate = model.BirthDate,
                    FirstName = model.FirstName,
                    FiscalCode = model.FiscalCode,
                    Gender = model.Gender,
                    LastName = model.LastName
                };
                
                var user = new UserDTO()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    IsAdmin = false,
                   // Person = pers
                };

                _userService.Add(user, pers);
                return View("Login");
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        public ActionResult Login()
        {
            

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Authorize(LoginViewModel loginViewModel)
        {
            string[] userDetails = _userService.CheckUser(loginViewModel.Username, loginViewModel.Password);
            if (userDetails[0] == "0")
            {
                loginViewModel.ErrorMessage = "Wrong username or password, please check and try again.";
                return View("Login", loginViewModel);
            }
            Session["UserId"] = userDetails[1];
            Session["Username"] = loginViewModel.Username;
            Session["IsAdmin"] = userDetails[2];

            if (userDetails[2]=="True")
            {
                return RedirectToAction("Index", "AdminUser");
            }
            return RedirectToAction("Banking");
        }

        public string Banking()
        {
            return "user banking will be here";
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}