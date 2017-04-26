using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Domain.Model.Mapping
{
    public class CurrentAccountMap : SubclassMap<CurrentAccount>
    {
        public CurrentAccountMap()
        {
            DiscriminatorValue("Current");

            Map(x => x.Restricted).Nullable();
        }
    }
}
