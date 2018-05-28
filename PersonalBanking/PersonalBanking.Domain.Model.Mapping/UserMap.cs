using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Domain.Model.Mapping
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Username).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.IsAdmin).Not.Nullable();

            References(x => x.Person).Not.Nullable().Cascade.SaveUpdate();

        }
    }
}
