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

            bankAccount.AccNum = bankAccountDto.AccNum;
            bankAccount.Balance = bankAccountDto.Balance;
            bankAccount.Currency = bankAccountDto.Currency;
            bankAccount.OpenDate = bankAccountDto.OpenDate;

            if (bankAccountDto.AccNum.Substring(bankAccountDto.AccNum.Length - 2).Contains("CR"))
            {
                ((CurrentAccount)bankAccount).Restricted = ((CurrentAccountDTO)bankAccountDto).Restricted;
               
            }
            else if (bankAccountDto.AccNum.Contains("CRED"))
            {
                ((CreditAccount)bankAccount).Rate = ((CreditAccountDTO)bankAccountDto).Rate;
                ((CreditAccount)bankAccount).Reimbursement = ((CreditAccountDTO)bankAccountDto).Reimbursement;
            }
            else if (bankAccountDto.AccNum.Contains("DEP"))
            {
                ((DepositAccount)bankAccount).DepIntRate = ((DepositAccountDTO)bankAccountDto).DepIntRate;   
            }

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

        public BankAccount GetBankAccountById(int bankAccountId)
        {
            return _bankAccountRepository.GetById(bankAccountId);
        }

        public BankAccount GetbankAccountByAccNumber(string bankAccountNumber)
        {
            return _bankAccountRepository.GetByAccountNumber(bankAccountNumber);
        }
    }
}
