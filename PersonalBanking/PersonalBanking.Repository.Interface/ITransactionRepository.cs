using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.Repository.Interface
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IList<Transaction> GetTranBySourceId(int bankAccountSourceId);
        IList<Transaction> GetTranByTargetId(int bankAccountTargetId);
        IList<Transaction> GetTranbyAmmoutLowerThen(decimal ammount);
        IList<Transaction> GetTranbyAmmountHigherThen(decimal ammount);

    }
}
