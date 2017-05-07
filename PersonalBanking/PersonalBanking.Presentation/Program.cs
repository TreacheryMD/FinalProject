using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            //IoC.RegisterAll();
            var bankAccountRepo = IoC.Resolve<IBankAccountRepository>();
            var personRepository = IoC.Resolve<IPersonRepository>();
            var cardRepository = IoC.Resolve<ICardRepository>();
            var billRepository = IoC.Resolve<IBillRepository>();
            var transactionRepository = IoC.Resolve<ITransactionRepository>();

            Person p1 = new Person("Ion", "Draganel", new DateTime(1991, 06, 10), "000000000001", GenderType.Male);
            Person p2 = new Person("Abbie", "Evans", new DateTime(1950, 01, 01), "000000000002", GenderType.Female);
            Person p3 = new Person("Kaiya", "Washington", new DateTime(1952, 02, 20), "000000000003", GenderType.Female);
            Person p4 = new Person("Kaydence", "Horton", new DateTime(1960, 03, 21), "000000000004", GenderType.Female);
            Person p5 = new Person("Melissa", "Buck", new DateTime(1968, 04, 11), "000000000005", GenderType.Female);
            Person p6 = new Person("Yasmine", "George", new DateTime(1964, 05, 12), "000000000006", GenderType.Female);
            Person p7 = new Person("Whitney", "Solis", new DateTime(1974, 06, 14), "000000000007", GenderType.Female);
            Person p8 = new Person("Patrick", "Wolfe", new DateTime(1971, 07, 12), "000000000008", GenderType.Male);
            Person p9 = new Person("Jaxson", "Mckee", new DateTime(1980, 08, 10), "000000000009", GenderType.Male);
            Person p10 = new Person("Emerson", "Robles", new DateTime(1982, 11, 10), "000000000010", GenderType.Male);
            Person p11 = new Person("Shamar", "Li", new DateTime(1983, 12, 08), "000000000011", GenderType.Male);
            Person p12 = new Person("Aydin", "Rocha", new DateTime(1984, 06, 09), "000000000012", GenderType.Male);
            Person p13 = new Person("Jovanni", "Zuniga", new DateTime(1993, 01, 05), "000000000013", GenderType.Male);
            Person p14 = new Person("Eddie", "Brewer", new DateTime(1992, 02, 02), "000000000014", GenderType.Male);

            List<Person> pList = new List<Person>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14 };
            personRepository.Add(pList);

            BankAccount ba1 = new CurrentAccount(p1, 50000, "111111", DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba2 = new CurrentAccount(p1, 4564566, "111112", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba3 = new CurrentAccount(p2, 787878, "111113", DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba4 = new CurrentAccount(p2, 898989, "111114", DateTime.Now, CurrencyTypes.RON);
            BankAccount ba5 = new CurrentAccount(p2, 454656, "111115", DateTime.Now, CurrencyTypes.RUB);
            BankAccount ba6 = new CurrentAccount(p3, 456, "111116", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba7 = new CurrentAccount(p3, 69866, "111117", DateTime.Now, CurrencyTypes.RUB);
            BankAccount ba8 = new CurrentAccount(p4, 6896896, "111118", DateTime.Now, CurrencyTypes.RON);
            BankAccount ba9 = new CurrentAccount(p4, 86868, "111119", DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba10 = new CurrentAccount(p5, 76767, "111120", DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba11 = new CurrentAccount(p5, 456453, "111121", DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba12 = new CurrentAccount(p6, 123123, "111122", DateTime.Now, CurrencyTypes.RUB);
            BankAccount ba13 = new CurrentAccount(p6, 0, "111123", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba14 = new CurrentAccount(p7, 456456, "111124", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba15 = new CurrentAccount(p7, 78945, "111125", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba16 = new CurrentAccount(p8, 0, "111126", DateTime.Now, CurrencyTypes.RUB);
            BankAccount ba17 = new CurrentAccount(p8, 4560, "111127", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba18 = new CurrentAccount(p8, 45688, "111128", DateTime.Now, CurrencyTypes.RUB);
            BankAccount ba19 = new CurrentAccount(p8, 477665, "111129", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba20 = new CurrentAccount(p8, 23534, "111130", DateTime.Now, CurrencyTypes.USD);
            BankAccount ba21 = new CurrentAccount(p10, 5389893, "111131", DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba22 = new CurrentAccount(p11, 0, "111132", DateTime.Now, CurrencyTypes.RUB);
            BankAccount ba23 = new CurrentAccount(p11, 123456, "111133", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba24 = new CurrentAccount(p12, 6789, "111134", DateTime.Now, CurrencyTypes.USD);
            BankAccount ba25 = new CurrentAccount(p12, 4567775, "111135", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba26 = new CurrentAccount(p12, 0, "111136", DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba27 = new CurrentAccount(p13, 1541232, "111137", DateTime.Now, CurrencyTypes.USD);
            BankAccount ba28 = new CurrentAccount(p13, 5656568, "111138", DateTime.Now, CurrencyTypes.USD);
            BankAccount ba29 = new CurrentAccount(p13, 568866, "111139", DateTime.Now, CurrencyTypes.EUR);

            BankAccount ba30 = new DepositAccount(p7, "111139", 500000, 12, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba31 = new DepositAccount(p1, "111140", 5000, 11, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba32 = new DepositAccount(p8, "111141", 60000, 7, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba33 = new DepositAccount(p11, "111142", 30000, 8, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba34 = new DepositAccount(p12, "111143", 20000, 3, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba35 = new DepositAccount(p13, "111144", 55000, 4, DateTime.Now, CurrencyTypes.EUR);
            BankAccount ba36 = new DepositAccount(p3, "111145", 880080, 5, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba37 = new DepositAccount(p4, "111146", 80000, 6, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba38 = new DepositAccount(p5, "111147", 900090, 6.66, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba39 = new DepositAccount(p6, "111148", 500541, 8, DateTime.Now, CurrencyTypes.MDL);
            BankAccount ba40 = new DepositAccount(p2, "111149", 55454, 9, DateTime.Now, CurrencyTypes.EUR);

            BankAccount ba41 = new CreditAccount(p1, "111150", 20000, DateTime.Now, CurrencyTypes.EUR, DateTime.Now.AddDays(300), 10);
            BankAccount ba42 = new CreditAccount(p13, "111151", 40000, DateTime.Now, CurrencyTypes.EUR, DateTime.Now.AddDays(250), 11);
            BankAccount ba43 = new CreditAccount(p8, "111152", 90000, DateTime.Now, CurrencyTypes.EUR, DateTime.Now.AddDays(244), 11);
            BankAccount ba44 = new CreditAccount(p11, "111153", 800000, DateTime.Now, CurrencyTypes.EUR, DateTime.Now.AddDays(800), 11);
            BankAccount ba45 = new CreditAccount(p8, "111154", 50000, DateTime.Now, CurrencyTypes.EUR, DateTime.Now.AddDays(500), 11);
            BankAccount ba46 = new CreditAccount(p12, "111155", 1110000, DateTime.Now, CurrencyTypes.EUR, DateTime.Now.AddDays(600), 11);

            List<BankAccount> allBankAccounts = new List<BankAccount>()
            {
                ba1 , ba2, ba3, ba4, ba5, ba6, ba7, ba8, ba9, ba10, ba11, ba12, ba13, ba14, ba15, ba16, ba17, ba18, ba19,
                ba20,ba21,ba22,ba23,ba24,ba25,ba26,ba27,ba28,ba29,ba30,ba31,ba32,ba33,ba34,ba35,ba36,ba37,ba38,ba39,ba40,ba41,ba42,ba43,ba44,ba45,ba46
            };

            bankAccountRepo.Add(allBankAccounts);


            Card card1 = new Card("Visa", 999, "0000111122223333", ba1, DateTime.Now.AddYears(3));
            Card card2 = new Card("Visa", 888, "0000111122224444", ba2, DateTime.Now.AddYears(3));
            Card card3 = new Card("MasterCard", 777, "0000111122225555", ba3, DateTime.Now.AddYears(3));
            Card card4 = new Card("MasterCard", 666, "0000111122266666", ba4, DateTime.Now.AddYears(3));
            Card card5 = new Card("MasterCard", 454, "0000111122227777", ba5, DateTime.Now.AddYears(3));
            Card card6 = new Card("MasterCard", 378, "0000111122228888", ba6, DateTime.Now.AddYears(3));
            Card card7 = new Card("Visa", 896, "0000111122229999", ba7, DateTime.Now.AddYears(3));
            Card card8 = new Card("Visa", 765, "0000111122230000", ba8, DateTime.Now.AddYears(3));
            Card card9 = new Card("Visa", 571, "0000111122231111", ba9, DateTime.Now.AddYears(3));
            Card card10 = new Card("Visa", 459, "000011112232222", ba10, DateTime.Now.AddYears(3));

            var cardList = new List<Card>() { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };

            cardRepository.Add(cardList);

            Bill bill1 = new Bill(150, "Starnet", new DateTime(2017, 04, 01), false, p1);
            Bill bill2 = new Bill(175, "Starnet", new DateTime(2017, 04, 01), false, p2);
            Bill bill3 = new Bill(130, "Starnet", new DateTime(2017, 04, 01), false, p3);
            Bill bill4 = new Bill(150, "Moldtelecom", new DateTime(2017, 04, 01), false, p4);
            Bill bill5 = new Bill(100, "Moldtelecom", new DateTime(2017, 04, 01), false, p5);
            Bill bill6 = new Bill(130, "Moldtelecom", new DateTime(2017, 04, 01), false, p6);
            Bill bill7 = new Bill(120, "Moldtelecom", new DateTime(2017, 04, 01), false, p7);
            Bill bill8 = new Bill(100, "Moldtelecom", new DateTime(2017, 04, 01), false, p8);

            var billsList = new List<Bill>() { bill1, bill2, bill3, bill4, bill5, bill6, bill7, bill8 };

            billRepository.Add(billsList);


            Transaction tr1 = new Transaction(ba1, ba11, 3000);
            Transaction tr2 = new Transaction(ba2, ba12, 400);
            Transaction tr3 = new Transaction(ba3, ba13, 500);
            Transaction tr4 = new Transaction(ba4, ba14, 80000);
            Transaction tr5 = new Transaction(ba5, ba15, 600);

            var allTrans = new List<Transaction>() { tr1, tr2, tr3, tr4, tr5 };

            transactionRepository.Add(allTrans);
        }
    }
}
