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
    public class SqlUserRepository : Repository<User>,IUserRepository
    {
        public SqlUserRepository(ISession session) : base(session)
        {
        }

        public IList<User> GetUserByPersonId(int personId)
        {
            return Session.QueryOver<User>().Where(w => w.Person.Id == personId).List();
        }
    }
}
