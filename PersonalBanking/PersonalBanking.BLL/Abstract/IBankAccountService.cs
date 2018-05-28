using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.Abstract
{
    public interface IBankAccountService
    {
        IList<BankAccountDTO> GetBankAccountDtos();
        BankAccountDTO GetBankAccounDtoById(int bankAccountId);
        void Save(BankAccountDTO bankAccountDto);
        void Delete(int bankAccountId);
        void Add(BankAccountDTO bankAccountDto);
        BankAccount GetBankAccountById(int bankAccountId);
        BankAccount GetbankAccountByAccNumber(string bankAccountNumber);
    }
}
