using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.BLL.DTO
{
    public class CurrentAccountDTO : BankAccountDTO
    {
        public bool Restricted { get; set; }
    }
}
