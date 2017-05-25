using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.Domain.Model.Account;
using PersonalBanking.Repository.Interface;
using NHibernate.Transform;

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

        public int GetUserPersonId(int userId)
        {
            var test = Session.QueryOver<User>()
                .Where(w => w.Id == userId)
                .JoinQueryOver(p => p.Person)
                .Select(s => s.Person.Id)
                .List<int>().SingleOrDefault();
                
                
                //.JoinQueryOver(p=>p.Person)
                //.Where(u=>u.);

            return test;
        }
        public bool IsUsernameUnique(string username)
        {
            var userString = Session.QueryOver<User>()
                .Where(w => w.Username == username)
                .Select(s => s.Username)
                .List<string>()
                .SingleOrDefault();
            return string.IsNullOrEmpty(userString);
        }
    }
}
