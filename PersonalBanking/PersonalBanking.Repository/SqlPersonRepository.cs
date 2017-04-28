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
    public class SqlPersonRepository : Repository<Person>, IPersonRepository
    {
        public SqlPersonRepository(ISession session) : base(session)
        {
        }

        public IList<Person> GetByFirstName(string firstName)
        {
            return Session.QueryOver<Person>().Where(w => w.FirstName == firstName).List();
        }

        public IList<Person> GetByFiscalCode(string fiscalCode)
        {
            return Session.QueryOver<Person>().Where(w => w.FiscalCode == fiscalCode).List();
        }

        public IList<Person> GetByLastName(string lastName)
        {
            return Session.QueryOver<Person>().Where(w => w.LastName == lastName).List();
        }
    }
}
