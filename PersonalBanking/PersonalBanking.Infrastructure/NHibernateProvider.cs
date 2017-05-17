using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using PersonalBanking.Domain.Model.Mapping;

namespace PersonalBanking.Infrastructure
{
    public class NHibernateProvider
    {
        private string _connectionString;

        public NHibernateProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory _sessionFactory;

        public ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = CreateSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }

        public ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey(_connectionString)))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(BankAccountMap).Assembly))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
            //.ExposeConfiguration(CreateSchema);

            return configuration.BuildSessionFactory();
        }

        private void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport(cfg);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);
        }
    }
}
