using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.BLL.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ITransaction _transaction;

        public BankAccountService(ITransaction transaction, IBankAccountRepository bankAccountRepository)
        {
            _transaction = transaction;
            _bankAccountRepository = bankAccountRepository;
        }

        public IList<BankAccountDTO> GetBankAccountDtos()
        {
            var bankAccounts = _bankAccountRepository.GetAll();
            var bankAccountsDto = AutoMapper.Mapper.Map<IList<BankAccount>, IList<BankAccountDTO>>(bankAccounts);

            return bankAccountsDto;
        }

        public BankAccountDTO GetBankAccounDtoById(int bankAccountId)
        {
            var bankAccount = _bankAccountRepository.GetById(bankAccountId);
            var bankAccoutDto = AutoMapper.Mapper.Map<BankAccount, BankAccountDTO>(bankAccount);

            return bankAccoutDto;
        }

        public void Save(BankAccountDTO bankAccountDto)
        {
            var bankAccount = _bankAccountRepository.GetById(bankAccountDto.Id);
            AutoMapper.Mapper.Map(bankAccountDto, bankAccount);

            _bankAccountRepository.SaveOrUpdate(bankAccount);
            _transaction.Commit();

        }

        public void Delete(int bankAccountId)
        {
            var bankAccount =  _bankAccountRepository.GetById(bankAccountId);
            _bankAccountRepository.Delete(bankAccount);
            _transaction.Commit();
        }

        public void Add(BankAccountDTO bankAccountDto)
        {
            throw new NotImplementedException();
        }
    }
}
