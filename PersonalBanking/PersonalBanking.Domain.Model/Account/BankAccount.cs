using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.Domain.Model.Account
{
    public enum CurrencyTypes
    {
        USD = 840,
        EUR = 978,
        RUB = 643,
        RON = 946,
        MDL = 487
    }

    public abstract class BankAccount : EntityBase
    {
        public virtual string AccNum { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual CurrencyTypes Currency { get; set; }
        public virtual Person Person { get; set; }

        protected BankAccount()
        {
            AccNum = "000000000000";
            Currency = CurrencyTypes.MDL;
        }

        protected BankAccount(Person person, decimal balance, string accNum, DateTime openDate, CurrencyTypes currency)
        {
            if (balance < 0) throw new Exception($"{nameof(balance)} can't be less than 0");
            if (string.IsNullOrWhiteSpace(accNum)) throw new ArgumentNullException(nameof(accNum));
            if (openDate < DateTime.Now.AddYears(-125))
                throw new Exception(
                    $"Invalid field:{nameof(openDate)} < {DateTime.Now.AddYears(-125).ToShortDateString()}");

            Person = person;
            AccNum = accNum;
            Balance = balance;
            OpenDate = openDate;
            Currency = currency;
        }

        protected BankAccount(string line)
        {
            var l = line.Split(';');
            //Person.FiscalCode = l[0];
            AccNum = l[1];
            Balance = Convert.ToDecimal(l[2]);
            OpenDate = DateTime.Parse(l[3]);
            Currency = (CurrencyTypes)Enum.Parse(typeof(CurrencyTypes), l[4]);
        }

        public virtual void ShowAccountInfo() => Console.Write(ToString());

        public static void ShowAccountInfo(IEnumerable<BankAccount> yourEnum, bool showSorted = false,
            bool ascending = false)
        {
            if (showSorted)
                yourEnum = ascending ? yourEnum.OrderBy(o => o.Balance) : yourEnum.OrderByDescending(o => o.Balance);
            foreach (var item in yourEnum) item.ShowAccountInfo();
        }

        public abstract void Freeze();

        public virtual void InBalance(decimal bal) => Balance += bal;
        public virtual void OutBalance(decimal bal) => Balance -= bal;

        public virtual void OutMaxBalance() => Balance -= Balance;

        public override string ToString() =>
            $"{Person.FiscalCode};{AccNum};{Balance};{OpenDate.ToShortDateString()};{Currency}";
    }
}
