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
    class SqlTransactionRepository : Repository<Transaction>,ITransactionRepository
    {
        public SqlTransactionRepository(ISession session) : base(session)
        {
        }

        public IList<Transaction> GetTranbyAmmountHigherThen(decimal ammount)
        {
            return Session.QueryOver<Transaction>().Where(w => ammount > w.Ammount).List();
        }

        public IList<Transaction> GetTranbyAmmoutLowerThen(decimal ammount)
        {
            return Session.QueryOver<Transaction>().Where(w => ammount < w.Ammount).List();
        }

        public IList<Transaction> GetTranBySourceId(int bankAccountSourceId)
        {
            return Session.QueryOver<Transaction>().Where(w => w.Source.Id == bankAccountSourceId).List();
        }

        public IList<Transaction> GetTranByTargetId(int bankAccountTargetId)
        {
            return Session.QueryOver<Transaction>().Where(w => w.Target.Id == bankAccountTargetId).List();
        }
    }
}
