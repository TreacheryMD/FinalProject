using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBanking.Domain.Model;
using System.ComponentModel.DataAnnotations;
using PersonalBanking.PresentationMVC.Validation;

namespace PersonalBanking.PresentationMVC.Models
{
    public class PersonViewModel
    {
        [Required]
        [Display(Name = "First name:")]
        public string FirstName { get; protected internal set; }
        [Required]
        [Display(Name = "Last name:")]
        public string LastName { get; protected internal set; }
        [Required]
        [Display(Name = "Birth date:")]
        [DataType(DataType.Date)]
        [ValidateDateRange()]
        public DateTime BirthDate { get; protected internal set; }
        [Display(Name = "Fiscal code:")]
        [Required]
        public string FiscalCode { get; protected internal set; }
        [Display(Name = "Gender:")]
        [Required]
        public GenderType Gender { get; protected internal set; }
    }
}