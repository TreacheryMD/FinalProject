using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Domain.Model.Mapping
{
    public class DepositAccountMap : SubclassMap<DepositAccount>
    {
        public DepositAccountMap()
        {
            DiscriminatorValue("Deposit");

            Map(x => x.DepIntRate).Nullable();
        }
    }
}
