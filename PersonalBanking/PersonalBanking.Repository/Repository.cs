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
            
                foreach (var entity in lEntity)
                {
                    Session.SaveOrUpdate(entity);
                }
              
            
        }

        public void SaveOrUpdate(T entity)
        {
            
                Session.SaveOrUpdate(entity);
               
        }

        public void Delete(T entity)
        {
         
               
                Session.Delete(entity);
 
        }

        public IList<T> GetAll()
        {
            return Session.QueryOver<T>().List();
        }

        public void Add(T entity)
        {
            Session.SaveOrUpdate(entity);
            
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id); 
        }
    }
}
