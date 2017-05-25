using PersonalBanking.Domain.Model.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.Repository.Interface
{
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
        BankAccount GetByAccountNumber(string accNumber);
        IList<CurrentAccount> GetCureAccountsByPersonId(int personId); 

    }
}
