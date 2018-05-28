using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBanking.Domain.Model
{
    public class Bill : EntityBase
    {
        public virtual decimal PayAmmount { get; set; }

        public virtual string ServiceName { get; set; }

        public virtual DateTime DateToPay { get; set; }

        public virtual bool PaidStatus { get; set; }

        public virtual Person Person { get; set; }

        public Bill()
        {

        }
        public Bill(decimal payAmmount,string serviceName,DateTime dateToPay,bool paidStatus,Person person)
        {
            PayAmmount = payAmmount;
            ServiceName = serviceName;
            DateToPay = dateToPay;
            PaidStatus = paidStatus;
            Person = person;
        }
    }
}
