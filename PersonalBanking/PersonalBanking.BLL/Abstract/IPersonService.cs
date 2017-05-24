using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.BLL.DTO;

namespace PersonalBanking.BLL.Abstract
{
    public interface IPersonService
    {
        IList<PersonDTO> GetPersonsDtos();
        PersonDTO GetPersonDtoById(int personId);
        void Save(PersonDTO personDto);
        void Delete(int personId);
        void Add(PersonDTO personDto);
    }
}
