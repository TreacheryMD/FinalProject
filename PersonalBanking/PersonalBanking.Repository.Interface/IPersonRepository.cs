using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.Repository.Interface
{
    public interface IPersonRepository :IRepository<Person>
    {
        IList<Person> GetByFirstName(string firstName);
        IList<Person> GetByLastName(string lastName);
        IList<Person> GetByFiscalCode(string fiscalCode);
    }
}
