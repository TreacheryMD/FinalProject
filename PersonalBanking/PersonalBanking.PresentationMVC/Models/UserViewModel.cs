using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalBanking.PresentationMVC.Models
{
    public class UserViewModel
    {
        [Display(Name = "User name:")]
        [Required]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Passowrd:")]
        public  string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        public virtual bool IsAdmin { get; set; }
        [Required]
        public virtual PersonViewModel Person { get; set; }
    }
}