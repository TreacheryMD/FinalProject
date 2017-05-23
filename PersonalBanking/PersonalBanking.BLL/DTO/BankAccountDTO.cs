using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.DTO
{
    public class BankAccountDTO : EntityBaseDTO
    {
        public string AccNum { get; set; }
        public decimal Balance { get; set; }
        public DateTime OpenDate { get; set; }
        public CurrencyTypes Currency { get; set; }
        public PersonDTO Person { get; set; }
    }
}
