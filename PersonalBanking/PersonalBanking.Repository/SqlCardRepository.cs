using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.Domain.Model;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.Repository
{
    public class SqlCardRepository : Repository<Card>,ICardRepository
    {
        public SqlCardRepository(ISession session) : base(session)
        {
        }

        public IList<Card> GetCardByBankAccountId(int bankAccountId)
        {
            return Session.QueryOver<Card>().Where(w => w.CardBankAccount.Id == bankAccountId).List();
        }

        public IList<Card> GetCardByNumber(string cardNumber)
        {
            return Session.QueryOver<Card>().Where(w => w.CardNumber == cardNumber).List();
        }

        
    }
}
