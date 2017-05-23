using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.PresentationMVC.Models
{
    public class CurrentAccountViewModel
    {
        public int Id { get; set; }
        public string AccNum { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public CurrencyTypes Currency { get; set; }
        //public PersonDTO Person { get; set; }
        public bool Restricted { get; set; }

    }
}