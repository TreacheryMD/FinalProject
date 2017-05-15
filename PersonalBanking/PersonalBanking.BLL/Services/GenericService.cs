using AutoMapper;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBanking.Repository.Interface;
using PersonalBanking.BLL.Abstract;

namespace PersonalBanking.BLL.Services
{
    public class GenericService<TDTOModel, TDomainModel> : IGenericService<TDTOModel> where TDTOModel : EntityBaseDTO where TDomainModel : EntityBase
    {
        private IRepository<TDomainModel> _genericRepository;
        private IMapper _mapper;

        public GenericService(IRepository<TDomainModel> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public void Add(TDTOModel entityBase)
        {
            _genericRepository.Add(_mapper.Map<TDTOModel, TDomainModel>(entityBase));
        }

        public void Delete(TDTOModel entityBase)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TDTOModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TDTOModel entityBase)
        {
            throw new NotImplementedException();
        }
    }
}
