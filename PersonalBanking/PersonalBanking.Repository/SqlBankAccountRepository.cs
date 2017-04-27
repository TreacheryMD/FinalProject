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

        public IList<BankAccount> GetByAccountNumber(string accNumber)
        {
            return Session.QueryOver<BankAccount>().Where(w => w.AccNum == accNumber).List();
        }
    }
}
