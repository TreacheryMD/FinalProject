using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.BLL.DTO
{
    public class CreditAccountDTO : BankAccountDTO
    {
        public DateTime Reimbursement { get; set; }

        public double Rate { get; set; }

    }
}
