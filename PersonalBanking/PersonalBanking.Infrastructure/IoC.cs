using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.Repository.Interface;
using PersonalBanking.Repository;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.BLL.Services;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Infrastructure
{
    public static class IoC
    {
        private static IKernel _kernel;
        public static void RegisterAll(IKernel kernel)
        {
            _kernel = kernel;
            _kernel.Register(
                Component.For(typeof(IBillRepository))
                    .ImplementedBy(typeof(SqlBillRepository)).LifestyleTransient());
            _kernel.Register(
                Component.For(typeof(IPersonRepository))
                    .ImplementedBy(typeof(SqlPersonRepository)).LifestyleTransient());
            _kernel.Register(
                Component.For(typeof(IBankAccountRepository))
                    .ImplementedBy(typeof(SqlBankAccountRepository)).LifestyleTransient());
            _kernel.Register(
                Component.For(typeof(ICardRepository))
                    .ImplementedBy(typeof(SqlCardRepository)).LifestyleTransient());

            _kernel.Register(
                Component.For(typeof(ITransactionRepository))
                    .ImplementedBy(typeof(SqlTransactionRepository)).LifestyleTransient());

            _kernel.Register(
                Component.For(typeof(IUserRepository))
                    .ImplementedBy(typeof(SqlUserRepository)).LifestyleTransient());

            //_kernel.Register(
            //    Component.For(typeof(IRegisterService))
            //        .ImplementedBy(typeof(RegisterService)).LifestyleTransient());

            _kernel.Register(
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository<>)).LifestyleTransient());

            _kernel.Register(
                Component.For(typeof(IGenericService<UserDTO>))
                    .ImplementedBy(typeof(GenericService<UserDTO, User>)).LifestyleTransient());


            _kernel.Register(Component.For<ISession>().UsingFactoryMethod(NHibernateProvider.GetSession).LifestyleTransient());
        }
        public static T Resolve<T>()
        {
            return _kernel.Resolve<T>();
        }
    }


        //public static class IoC
        //{
        //    private static readonly UnityContainer Container;

        //    static IoC()
        //    {
        //        if (Container == null)
        //        {
        //            Container = new UnityContainer();
        //        }
        //    }

        //    public static void RegisterAll()
        //    {
        //        Container.RegisterType<IBillRepository,SqlBillRepository >();
        //        Container.RegisterType<IPersonRepository, SqlPersonRepository>();
        //        Container.RegisterType<IBankAccountRepository, SqlBankAccountRepository>();
        //        Container.RegisterType<ICardRepository, SqlCardRepository>();
        //        Container.RegisterType<ITransactionRepository, SqlTransactionRepository>();
        //        Container.RegisterInstance(NHibernateProvider.GetSession());
        //    }

        //    public static T Resolve<T>()
        //    {
        //        return Container.Resolve<T>();
        //    }
        //}
    }
