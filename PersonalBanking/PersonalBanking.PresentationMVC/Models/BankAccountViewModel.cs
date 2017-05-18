using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.PresentationMVC.Models
{
    public class BankAccountViewModel
    {
        public string AccNum { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public CurrencyTypes Currency { get; set; }
        public DateTime Reimbursement { get; set; }
        public double Rate { get; set; }
        public bool Restricted { get; set; }
        public double DepIntRate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FiscalCode { get; set; }
    }
}