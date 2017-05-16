using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.PresentationMVC.Models;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUserService _userService; 


        public AdminController(IUserService userService)
        {
            _userService = userService;

            //_userRepository = userRepository;
            //_bankAccountRepository = bankAccountRepository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users()
        {
            //var allUsers = _userRepository.GetAll();

            var allUsers = _userService.GetUserDtos();   

            var userViewModels = AutoMapper.Mapper.Map<IList<UserViewModel>>(allUsers);

            return View(userViewModels);
        }

        public ActionResult EditUser(int userId)
        {
            var allUsers = _userService.GetUserDtos();
            return null;
        }

        public ActionResult BankAccounts()
        {
           var allBankAccounts =  _bankAccountRepository.GetAll();

           return View(allBankAccounts);
        }
    }
}