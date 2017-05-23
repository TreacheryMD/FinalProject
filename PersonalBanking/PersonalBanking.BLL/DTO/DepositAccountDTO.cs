using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.BLL.DTO
{
    public class DepositAccountDTO : BankAccountDTO
    {
        public double DepIntRate { get; set; }
    }
}
