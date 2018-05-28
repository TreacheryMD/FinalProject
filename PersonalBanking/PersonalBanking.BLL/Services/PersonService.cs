using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Repository.Interface;

namespace PersonalBanking.BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITransaction _transaction;

        public PersonService(IPersonRepository personRepository, ITransaction transaction)
        {
            _personRepository = personRepository;
            _transaction = transaction;
        }

        public IList<PersonDTO> GetPersonsDtos()
        {
            var persons = _personRepository.GetAll();
            IList<PersonDTO> personsDto = new List<PersonDTO>();
            return AutoMapper.Mapper.Map(persons, personsDto);
        }

        public PersonDTO GetPersonDtoById(int personId)
        {
            throw new NotImplementedException();
        }

        public void Save(PersonDTO personDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int personId)
        {
            throw new NotImplementedException();
        }

        public void Add(PersonDTO personDto)
        {
            throw new NotImplementedException();
        }
    }
}
