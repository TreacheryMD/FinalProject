using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.BLL.DTO
{
    public class TransferingDTO
    {
        public string SourceBankAccountNumber { get; set; }
        public string TargetBankAccountNumber { get; set; }
        public decimal Ammount { get; set; }
        public int Id { get; set; }
    }
}
