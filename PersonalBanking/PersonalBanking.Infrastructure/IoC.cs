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
using PersonalBanking.Domain.Model;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.Infrastructure
{
    public class IoC
    {
        private static IKernel _kernel;
        private static string _connectionString;

        public IoC(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RegisterAll(IKernel kernel)
        {
            _kernel = kernel;
            NHibernateProvider provider = new NHibernateProvider(_connectionString);
            //_kernel.Register(Classes.FromAssembly(typeof(IBillRepository).Assembly)
            //    .BasedOn<SqlBillRepository>()
            //    .WithService.FromInterface()
            //    .LifestylePerWebRequest());

            //_kernel.Register(Classes.FromAssembly(typeof(IUserService).Assembly)
            //    .BasedOn<UserService>()
            //    .WithService.FromInterface()
            //    .LifestylePerWebRequest());

            _kernel.Register(
                Component.For(typeof(IBillRepository))
                    .ImplementedBy(typeof(SqlBillRepository)).LifestylePerWebRequest());
            _kernel.Register(
                Component.For(typeof(IPersonRepository))
                    .ImplementedBy(typeof(SqlPersonRepository)).LifestylePerWebRequest());
            _kernel.Register(
                Component.For(typeof(IBankAccountRepository))
                    .ImplementedBy(typeof(SqlBankAccountRepository)).LifestylePerWebRequest());
            _kernel.Register(
                Component.For(typeof(ICardRepository))
                    .ImplementedBy(typeof(SqlCardRepository)).LifestylePerWebRequest());

            _kernel.Register(
                Component.For(typeof(ITransactionRepository))
                    .ImplementedBy(typeof(SqlTransactionRepository)).LifestylePerWebRequest());

            _kernel.Register(
                Component.For(typeof(IUserRepository))
                    .ImplementedBy(typeof(SqlUserRepository)).LifestylePerWebRequest());


            _kernel.Register(
                Component.For(typeof(IRepository<>))
                    .ImplementedBy(typeof(Repository<>)).LifestylePerWebRequest());

            _kernel.Register(
                Component.For(typeof(IGenericService<UserDTO>))
                    .ImplementedBy(typeof(GenericService<UserDTO, User>)).LifestylePerWebRequest());

            _kernel.Register(
                Component.For(typeof(IGenericService<PersonDTO>))
                    .ImplementedBy(typeof(GenericService<PersonDTO, Person>)).LifestylePerWebRequest());

            _kernel.Register(
                Component.For(typeof(IUserService))
                    .ImplementedBy(typeof(UserService)).LifestylePerWebRequest());

            _kernel.Register(
                Component.For(typeof(IBankAccountService))
                    .ImplementedBy(typeof(BankAccountService)).LifestylePerWebRequest());


            //_kernel.Register(Component.For<ISession>().UsingFactoryMethod(NHibernateProvider.GetSession).LifestylePerWebRequest());




            kernel.Register(Component.For<ISessionFactory>().Instance(provider.CreateSessionFactory()).LifestyleSingleton());
            kernel.Register(Component.For<ISession>().UsingFactory((ISessionFactory sessionFactory) => sessionFactory.OpenSession()).LifestylePerWebRequest());
            kernel.Register(Component.For<ITransaction>().UsingFactory((ISession session) => session.BeginTransaction()).LifestylePerWebRequest());

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
