using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.PresentationMVC.Models;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class AdminUserController : Controller
    {
        //private readonly IUserRepository _userRepository;
        //private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUserService _userService; 


        public AdminUserController(IUserService userService)
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
            var user = _userService.GetUserById(userId);
            var userView = new UserViewModel();
            return View(AutoMapper.Mapper.Map(user, userView));
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditUser(UserViewModel userView)
        {
            var user = new UserDTO();
            user = AutoMapper.Mapper.Map(userView, user);
            _userService.Save(user);
            return View();
        }

        public ActionResult DeleteUser(int userId)
        {
            var user = _userService.GetUserById(userId);
            var userView = new UserViewModel();
            AutoMapper.Mapper.Map(user, userView);
            return View(userView);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DeleteUser(UserDTO userDTO)
        {
            _userService.Delete(userDTO);
            return RedirectToAction("Users");
        }




    }
}