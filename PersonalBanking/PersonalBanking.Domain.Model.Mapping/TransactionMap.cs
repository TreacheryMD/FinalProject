using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace PersonalBanking.Domain.Model.Mapping
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            
            References(x => x.Source).Not.Nullable();
            References(x => x.Target).Not.Nullable();

            Map(x => x.Ammount).Not.Nullable();
            Map(x => x.CurrencyType).Not.Nullable();
            Map(x => x.Date).Not.Nullable();
        }
    }
}
