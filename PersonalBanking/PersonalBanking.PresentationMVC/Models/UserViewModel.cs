using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBanking.PresentationMVC.Models
{
    public class UserViewModel
    {
        public int  Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

    }
}