using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalBanking.BLL.Abstract;
using PersonalBanking.BLL.DTO;
using PersonalBanking.BLL.Services;
using PersonalBanking.Domain.Model;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>().ForMember(data=>data.Person, opt=>opt.Ignore());
            CreateMap<BillDTO, Bill>().ReverseMap();

            CreateMap<BankAccountDTO, BankAccount>().ForMember(dest => dest.Person, opt => opt.Ignore());

            CreateMap<BankAccount, BankAccountDTO>()
                .Include<CurrentAccount, CurrentAccountDTO>()
                .Include<DepositAccount, DepositAccountDTO>()
                .Include<CreditAccount, CreditAccountDTO>();
            CreateMap<CurrentAccount, CurrentAccountDTO>();
            CreateMap<DepositAccount, DepositAccountDTO>();
            CreateMap<CreditAccount, CreditAccountDTO>();
        }
    }
}
