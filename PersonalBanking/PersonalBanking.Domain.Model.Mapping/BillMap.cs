using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace PersonalBanking.Domain.Model.Mapping
{
    class BillMap : ClassMap<Bill>
    {
        public BillMap()
        {
            Id(x => x.Id);

            Map(x => x.PayAmmount).Not.Nullable();
            Map(x => x.ServiceName).Not.Nullable();
            Map(x => x.DateToPay).Not.Nullable();
            Map(x => x.PaidStatus).Not.Nullable();
            References(x => x.Person);


        }
    }
}
