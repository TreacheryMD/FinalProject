using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Domain.Model
{
    public class Card : EntityBase
    {
        public virtual string CardType { get; set; }
        public virtual int Cvv { get; set; }

        public virtual string CardNumber { get; set; }

        public virtual BankAccount CardBankAccount { get; set; }

        public virtual DateTime ExpireDate { get; set; }

        public Card()
        {

        }
    }
}
