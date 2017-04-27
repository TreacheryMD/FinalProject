using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.Domain.Model;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ISession Session;

        public Repository(ISession session)
        {
            Session = session;
        }

        public void Add(List<T> lEntity)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                foreach (var entity in lEntity)
                {
                    Session.SaveOrUpdate(entity);
                }
                transaction.Commit();
            }
        }

        public void Add(T entity)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
            using (ITransaction transaction = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public List<T> GetAll()
        {
            return Session.QueryOver<T>().List().ToList();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id); 
        }
    }
}
