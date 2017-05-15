using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.BLL.DTO
{
    public class BillDTO : EntityBaseDTO
    {
        public decimal PayAmmount { get; set; }

        public string ServiceName { get; set; }

        public DateTime DateToPay { get; set; }

        public bool PaidStatus { get; set; }

        public PersonDTO Person { get; set; }
    }
}
