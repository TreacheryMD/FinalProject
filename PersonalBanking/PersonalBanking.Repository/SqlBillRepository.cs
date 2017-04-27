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
    public class SqlBillRepository : Repository<Bill>, IBillRepository
    {
        public SqlBillRepository(ISession session) : base(session)
        {
        }
        public IList<Bill> GetBillsByPersonId(int personId)
        {
            return Session.QueryOver<Bill>()
                .Where(w => w.Person.Id == personId)
                .List();
        }
    }
}
