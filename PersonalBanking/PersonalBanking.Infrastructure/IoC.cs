using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PersonalBanking.Repository.Interface;
using PersonalBanking.Repository;

namespace PersonalBanking.Infrastructure
{
    public static class IoC
    {
        private static readonly UnityContainer Container;

        static IoC()
        {
            if (Container == null)
            {
                Container = new UnityContainer();
            }
        }

        public static void RegisterAll()
        {
            //Container.RegisterType<IClientRepository, ClientRepository>();
            Container.RegisterType<IPersonRepository, SqlPersonRepository>();
            Container.RegisterType<IBankAccountRepository, SqlBankAccountRepository>();
            Container.RegisterInstance(NHibernateProvider.GetSession());
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
