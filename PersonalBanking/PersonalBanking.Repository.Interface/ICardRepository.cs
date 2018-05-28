using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.Repository.Interface
{
    public interface ICardRepository : IRepository<Card>
    {
        IList<Card> GetCardByNumber(string cardNumber);
        IList<Card> GetCardByBankAccountId(int bankAccountId);
    }
}
