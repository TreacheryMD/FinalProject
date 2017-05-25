using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.BLL.Services
{
    public class ClientBankingService : IClientBankingService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITransaction _transaction;

        public ClientBankingService(IBankAccountRepository bankAccountRepository, ITransaction transaction, IUserRepository userRepository)
        {
            _bankAccountRepository = bankAccountRepository;
            _transaction = transaction;
            _userRepository = userRepository;
        }

        public IList<CurrentAccountDTO> GetCurrentAccountDtos(int userId)
        {
            int userPersonId = _userRepository.GetUserPersonId(userId);
            var currentAccounts = _bankAccountRepository.GetCureAccountsByPersonId(userPersonId);
            IList<CurrentAccountDTO> currentAccountsDto = new List<CurrentAccountDTO>();
            AutoMapper.Mapper.Map(currentAccounts, currentAccountsDto);
            return currentAccountsDto;
        }

        public IList<CreditAccountDTO> GetCreditAccountDtos()
        {
            throw new NotImplementedException();
        }

        public IList<DepositAccountDTO> GetDepositAccountDtos()
        {
            throw new NotImplementedException();
        }
    }
}

