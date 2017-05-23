using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Domain.Model.Mapping
{
    public class BankAccountMap : ClassMap<BankAccount>
    {
        public BankAccountMap()
        {
            DiscriminateSubClassesOnColumn("ClassType").Not.Nullable();

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.AccNum).Unique().Not.Nullable();
            Map(x => x.Balance).Not.Nullable();
            Map(x => x.OpenDate).Not.Nullable();
            Map(x => x.Currency).Not.Nullable();

            References(x => x.Person).Not.Nullable().LazyLoad();//.Column("Id").ForeignKey("BankAccount_Person_Id").Not.Nullable();


        }
    }
}