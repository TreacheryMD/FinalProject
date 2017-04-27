using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Impl;
using PersonalBanking.Domain.Model;
using PersonalBanking.Infrastructure;
using PersonalBanking.Repository.Interface;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.RegisterAll();
            var bankAccountRepo = IoC.Resolve<IBankAccountRepository>();
            var personRepository = IoC.Resolve<IPersonRepository>();

            //Person p1 = new Person("Ion","Draganel",new DateTime(1991,06,10),"000000000001",GenderType.Male);

            //BankAccount p1CurentMdl = new CurrentAccount(p1,0,"111111",DateTime.Now, CurrencyTypes.MDL);
            //BankAccount p1CurentEur = new CurrentAccount(p1, 0, "111112", DateTime.Now, CurrencyTypes.EUR);
            //p1.AddBankAccount(p1CurentMdl);
            //p1.AddBankAccount(p1CurentEur);

            //personRepository.Add(p1);
            var acc = bankAccountRepo.GetById(5);

            bankAccountRepo.Delete(acc);

        }
    }
}
