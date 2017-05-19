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
            //CreateMap<CardDTO, Card>().ReverseMap();
            //CreateMap<CreditAccountDTO, CreditAccount>().ReverseMap();
            //CreateMap<CurrentAccountDTO, CurrentAccount>().ReverseMap();
            //CreateMap<DepositAccountDTO, DepositAccount>().ReverseMap();
            // CreateMap<TransactionDTO, Transaction>().ReverseMap();
            //CreateMap<BankAccountDTO, BankAccount>();

            //CreateMap<BankAccount, BankAccountDTO>()
            //    .ForMember(dest => dest.PersonFiscalCode, opt => opt.MapFrom(src => src.Person.FiscalCode));


        }
    }
}
