using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.Domain.Model.Account
{
    public class DepositAccount : BankAccount
    {
        public virtual double DepIntRate { get; set; }

        public DepositAccount(Person person, string accNum, decimal balance, double depositInterestRate, DateTime openDate, CurrencyTypes currency) :
            base(person, balance, accNum + "DEP", openDate, currency)
        {
            if (depositInterestRate <= 0) throw new Exception($"Invalid field:{nameof(depositInterestRate)}<=0");
            DepIntRate = depositInterestRate;
        }

        public DepositAccount(string line) : base(line)
        {
            var l = line.Split(';');
            DepIntRate = Convert.ToDouble(l[5]);
        }

        public DepositAccount()
        {
            AccNum += "DEP";
        }
        public override void ShowAccountInfo() => Console.WriteLine(ToString());

        public virtual void CalcDepAftMonths(int numbOfMonths)
        {
            for (int i = 0; i < numbOfMonths; i++) InBalance(Balance * (decimal)DepIntRate / 100 / 12);
        }

        public override string ToString() => base.ToString() + $";{DepIntRate}";

        public override void Freeze()
        {
            throw new NotImplementedException();
        }
    }
}
