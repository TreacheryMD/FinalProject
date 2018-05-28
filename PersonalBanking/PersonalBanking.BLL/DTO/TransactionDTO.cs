using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.DTO
{
    class TransactionDTO : EntityBaseDTO
    {
        public  BankAccountDTO Source { get; set; }
        public  BankAccountDTO Target { get; set; }
        public  decimal Ammount { get; set; }
        public  CurrencyTypes CurrencyType { get; set; }
        public  DateTime Date { get; set; }

    }
}
