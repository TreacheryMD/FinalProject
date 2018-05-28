using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL.Abstract
{
    public interface IClientBankingService
    {
        IList<CurrentAccountDTO> GetCurrentAccountDtos(int userId);
        IList<CreditAccountDTO> GetCreditAccountDtos();
        IList<DepositAccountDTO> GetDepositAccountDtos();
    }
}
