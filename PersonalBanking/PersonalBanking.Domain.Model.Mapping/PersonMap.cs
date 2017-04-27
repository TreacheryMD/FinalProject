using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace PersonalBanking.Domain.Model.Mapping
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.BirthDate).Not.Nullable();
            Map(x => x.FiscalCode).Unique().Not.Nullable();
            Map(x => x.Gender).Not.Nullable();

            HasMany(x => x.BankAccounts).Inverse().KeyColumn("Person_Id").Cascade.AllDeleteOrphan().Cascade.SaveUpdate();
        }
    }
}
