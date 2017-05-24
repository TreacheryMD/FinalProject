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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string FiscalCode { get; set; }
        [Required]
        public GenderType Gender { get; set; }
    }
}