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
    }
}
