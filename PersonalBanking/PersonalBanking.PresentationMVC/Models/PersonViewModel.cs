using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.PresentationMVC.Models
{
    public class PersonViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Fiscal code")]
        public string FiscalCode { get; set; }
        [Required]
        public GenderType Gender { get; set; }
    }
}