using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.Domain.Model.Account
{
    public class CreditAccount : BankAccount
    {
        public virtual DateTime Reimbursement { get; }

        public virtual double Rate { get; }

        public CreditAccount(Person person, string accNum, decimal newCreditAmmout, DateTime openDate, CurrencyTypes currency, DateTime reimbursementDate, double rate) :
            base(person, newCreditAmmout, accNum + "CRED", openDate, currency)
        {
            if (reimbursementDate < DateTime.Now) throw new Exception($"Invalid field:{nameof(reimbursementDate)}<{DateTime.Now.ToShortDateString()}");
            Reimbursement = reimbursementDate;
            Rate = rate;
        }
        public CreditAccount(string line) : base(line)
        {
            var l = line.Split(';');
            Reimbursement = DateTime.Parse(l[5]);
        }
        public CreditAccount()
        {
            AccNum += "CRED";
        }

        public override void ShowAccountInfo()
        {
            base.ShowAccountInfo();
            Console.WriteLine();
        }
        public override void InBalance(decimal bal)
        {
            if (Balance - bal < 0) throw new Exception($"You transfer too much in Credit account: {Balance - bal}");
            Balance -= bal;
        }

        public override string ToString() => base.ToString() + $";{Reimbursement.ToShortDateString()}";

        public override void Freeze()
        {
            throw new NotImplementedException();
        }
    }
}
