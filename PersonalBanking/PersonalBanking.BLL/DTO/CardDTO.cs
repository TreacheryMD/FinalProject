using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.BLL.DTO
{
    public class CardDTO : EntityBaseDTO
    {
        public string CardType { get; set; }
        public int Cvv { get; set; }
        public string CardNumber { get; set; }
        public BankAccountDTO CardBankAccount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
