using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace PersonalBanking.Domain.Model.Mapping
{
    class CardMap : ClassMap<Card>
    {
        public CardMap()
        {
            Id(x => x.Id);

            Map(x => x.CardType).Not.Nullable();
            Map(x => x.Cvv).Not.Nullable();
            Map(x => x.CardNumber).Not.Nullable();
            Map(x => x.ExpireDate).Not.Nullable();

            References(x => x.CardBankAccount).Not.Nullable();  
        }

       
    }
}
