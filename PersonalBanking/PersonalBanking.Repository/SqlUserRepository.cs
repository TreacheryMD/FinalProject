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

        public string[] CheckUser(string userName, string password)
        {

            var result = Session.QueryOver<User>().Where(w => w.Username == userName && w.Password == password).SingleOrDefault();
            if (result == null) return new string[] {"0"};
            return new string[]{"1",result.Id.ToString(), result.IsAdmin.ToString()};
        }

    }
}
