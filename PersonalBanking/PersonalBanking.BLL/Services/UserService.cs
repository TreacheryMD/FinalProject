using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;
using PersonalBanking.Repository.Interface;
using PersonalBanking.Domain.Model;
using NHibernate;

namespace PersonalBanking.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITransaction _transaction;

        public UserService(IUserRepository userRepository, ITransaction transaction)
        {
            this._userRepository = userRepository;
            this._transaction = transaction;
        }
        public IList<UserDTO> GetUserDtos()
        {
            var users = _userRepository.GetAll();

            var userDtoList = AutoMapper.Mapper.Map<IList<User>, IList<UserDTO>>(users);
            return userDtoList;
        }

        public UserDTO GetUserById(int userId)
        {
            var user = _userRepository.GetById(userId);
            var userDTO = AutoMapper.Mapper.Map<User, UserDTO>(user);
            return userDTO;
        }

        public void Save(UserDTO userDTO)
        {
            var user = _userRepository.GetById(userDTO.Id);
            AutoMapper.Mapper.Map(userDTO, user);

            _userRepository.SaveOrUpdate(user);
            _transaction.Commit();
        }

        public void Delete(UserDTO userDTO)
        {
            var user = _userRepository.GetById(userDTO.Id);
           _userRepository.Delete(user);
           _transaction.Commit();
        }

        public void Add(UserDTO userDTO, PersonDTO personDTO)
        {
            var user = new User();
            var person = new Person();
            user = AutoMapper.Mapper.Map(userDTO, user);
            user.Person = AutoMapper.Mapper.Map(personDTO, person);
            _userRepository.SaveOrUpdate(user);
            _transaction.Commit();
        }

        public string[] CheckUser(string userName, string password)
        {
           return _userRepository.CheckUser(userName, password);
        }

        public bool IsUsernameUnique(string userName)
        {
            return _userRepository.IsUsernameUnique(userName);
        }
    }
}

