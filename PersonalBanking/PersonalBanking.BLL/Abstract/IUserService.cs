using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.DTO;

namespace PersonalBanking.BLL.Abstract
{
    public interface IUserService
    {
        IList<UserDTO> GetUserDtos();
        //UserDTO GetUserDetailsByID(int userId);
    }
}
