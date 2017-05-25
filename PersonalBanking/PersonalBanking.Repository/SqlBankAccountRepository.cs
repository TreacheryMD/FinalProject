using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.Domain.Model.Account;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.Repository
{
    public class SqlBankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public SqlBankAccountRepository(ISession session) : base(session)
        {
        }

        public BankAccount GetByAccountNumber(string accNumber)
        {
            return Session.QueryOver<BankAccount>()
                .Where(w=>w.AccNum == accNumber)
                .SingleOrDefault();
        }

        public IList<CurrentAccount> GetCureAccountsByPersonId(int personId)
        {
            return Session.QueryOver<CurrentAccount>().Where(w => w.Person.Id == personId).List();
        }
    }
}
