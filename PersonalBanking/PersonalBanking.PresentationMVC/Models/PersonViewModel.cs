using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBanking.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace PersonalBanking.PresentationMVC.Models
{
    public class PersonViewModel
    {
        [Required]
        [Display(Name = "First name:")]
        public string FirstName { get; protected internal set; }
        [Display(Name = "Last name:")]
        public string LastName { get; protected internal set; }
        [Display(Name = "Birth date:")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; protected internal set; }
        [Display(Name = "Fiscal code:")]
        public string FiscalCode { get; protected internal set; }
        [Display(Name = "Gender:")]
        public GenderType Gender { get; protected internal set; }
    }
}