﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBanking.PresentationMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }
    }
}