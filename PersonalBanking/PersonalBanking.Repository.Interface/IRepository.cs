using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Domain.Model;

namespace PersonalBanking.Repository.Interface
{
    public interface IRepository<T> where T : EntityBase
    {
        void SaveOrUpdate(T entity);
        void Add(List<T> lEntity);
        void Delete(T entity); 
        T GetById(int id); 
        IList<T> GetAll();
    }
}
