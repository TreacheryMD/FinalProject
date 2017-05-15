using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.DTO;

namespace PersonalBanking.BLL.Abstract
{
    public interface IGenericService<T> where T : EntityBaseDTO
    {
        void Add(T entityBase);
        void Update(T entityBase);
        IEnumerable<T> GetAll();
        void Delete(T entityBase);
    }
}
