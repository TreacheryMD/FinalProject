using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.Repository.Interface
{
    public interface IBillRepository : IRepository<Bill>
    {
        IList<Bill> GetBillsByPersonId(int id);
    }
}
