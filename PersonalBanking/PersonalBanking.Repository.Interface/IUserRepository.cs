using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        IList<User> GetUserByPersonId(int personId);
        string[] CheckUser(string userName, string password);
    }
}
