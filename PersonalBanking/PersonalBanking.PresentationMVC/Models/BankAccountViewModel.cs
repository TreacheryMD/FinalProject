using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.PresentationMVC.Models
{
    public class BankAccountViewModel
    {
        [Required]
        public string AccNum { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public DateTime OpenDate { get; set; }
        [Required]
        public CurrencyTypes Currency { get; set; }
        public DateTime Reimbursement { get; set; }
        public double Rate { get; set; }
        public bool Restricted { get; set; }
        public double DepIntRate { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string FiscalCode { get; set; }

        public int Id { get; set; }
    }
}