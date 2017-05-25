using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.Domain.Model;
using PersonalBanking.Domain.Model.Account;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.BLL.Services
{
    public class TransferManagerService : ITransferManagerService
    {
        private readonly ICursManagerService _cursManager;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IBankAccountService _bankAccountService;
        private readonly ITransaction _transaction;


        public TransferManagerService(ICursManagerService cursManager, IRepository<Transaction> transactionRepository, IBankAccountService bankAccountService, ITransaction transaction)
        {
            _cursManager = cursManager;
            _transactionRepository = transactionRepository;
            _bankAccountService = bankAccountService;
            _transaction = transaction;
        }

        public void ExecuteTransfer(string sourceBankAccountNumber, string targetBankAccountNumber, decimal ammount)
        {
            
            var sourceBankAccount = _bankAccountService.GetbankAccountByAccNumber(sourceBankAccountNumber);
            var targetBankAccount = _bankAccountService.GetbankAccountByAccNumber(targetBankAccountNumber);

            if (sourceBankAccount.GetType().ToString().Contains("CreditAccount")) throw new Exception("source can not be CreditAccount");
            var convertAmount = _cursManager.CurrencyConvert(sourceBankAccount.Currency, targetBankAccount.Currency, ammount);
            if (CanTransfer(sourceBankAccount, ammount))
            {
                sourceBankAccount.OutBalance(ammount);
                targetBankAccount.InBalance(convertAmount);
                _transactionRepository.Add(new Transaction(sourceBankAccount, targetBankAccount, ammount));
                _transaction.Commit();

            }
            else
            {
                throw new Exception("Not enought money on source account");
            }
        }

        private bool CanTransfer(BankAccount acc1, decimal amount) => acc1.Balance >= amount;
    }
}
