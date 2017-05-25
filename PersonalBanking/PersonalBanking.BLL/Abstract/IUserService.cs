using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.Abstract
{
    public interface IUserService
    {
        IList<UserDTO> GetUserDtos();
        UserDTO GetUserById(int userId);
        void Save(UserDTO userDTO);
        void Delete(UserDTO userDTO);
        void Add(UserDTO user, PersonDTO person);
        string[] CheckUser(string userName, string password);

        bool IsUsernameUnique(string userName);
    }
}
