using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.Abstract
{
    public interface ITransferManagerService
    {
        void ExecuteTransfer(string sourceBankAccountNumber, string targetBankAccountNumber, decimal ammount);
    }
}
