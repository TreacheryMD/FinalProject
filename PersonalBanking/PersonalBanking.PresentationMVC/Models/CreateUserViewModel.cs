using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using PersonalBanking.Domain.Model;
using PersonalBanking.PresentationMVC.Validation;

namespace PersonalBanking.PresentationMVC.Models
{
    public class CreateUserViewModel
    {
        [Display(Name = "User name:")]
        [Required]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password:")]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,}", ErrorMessage = "Password is to simple.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Passowrd:")]
        public  string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        [Required]
        [Display(Name = "First name:")]
        public string FirstName { get; protected internal set; }
        [Required]
        [Display(Name = "Last name:")]
        public string LastName { get; protected internal set; }
        [Required]
        [Display(Name = "Birth date:")]
        [DataType(DataType.Date)]
        [ValidateDateRange]
        public DateTime BirthDate { get; protected internal set; }
        [Display(Name = "Fiscal code:")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Fiscal code: numbers only.")]
        public string FiscalCode { get; protected internal set; }
        [Display(Name = "Gender:")]
        [Required]
        public GenderType Gender { get; protected internal set; }
    }
}