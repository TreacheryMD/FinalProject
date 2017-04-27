using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Domain.Model
{
    public class Transaction : EntityBase
    {
        public virtual BankAccount Source { get; }
        public virtual BankAccount Target { get; }
        public virtual decimal Ammount { get; }
        public virtual CurrencyTypes CurrencyType { get; }
        public virtual DateTime Date { get; }

        public Transaction(BankAccount source, BankAccount target, decimal ammount)
        {
            Source = source;
            Target = target;
            Ammount = ammount;
            Date = DateTime.Now;
            CurrencyType = source.Currency;
        }

        public Transaction()
        {
            
        }
    }
}
