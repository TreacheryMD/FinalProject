using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository _userRepository)
        {
            this._userRepository = _userRepository;
        }
        public IList<UserDTO> GetUserDtos()
        {
            var users = _userRepository.GetAll();

            var userDtoList = AutoMapper.Mapper.Map<IList<User>,IList<UserDTO>>(users);
            return userDtoList;
        }
    }
}
