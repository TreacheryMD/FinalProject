using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Domain.Model.Mapping
{
    public class CreditAccountMap : SubclassMap<CreditAccount>
    {
        public CreditAccountMap()
        {
            DiscriminatorValue("Credit");

            Map(x => x.Reimbursement).Nullable();
            Map(x => x.Rate).Nullable();
        }
    }
}
