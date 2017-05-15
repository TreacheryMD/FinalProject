using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PersonalBanking.BLL.DTO;
using PersonalBanking.Domain.Model;
using PersonalBanking.Domain.Model.Account;

namespace PersonalBanking.BLL
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<BillDTO, Bill>().ReverseMap();
            //CreateMap<CardDTO, Card>().ReverseMap();
            //CreateMap<CreditAccountDTO, CreditAccount>().ReverseMap();
            //CreateMap<CurrentAccount, CurrentAccount>().ReverseMap();
            //CreateMap<DepositAccount, DepositAccount>().ReverseMap();
            //CreateMap<TransactionDTO, Transaction>().ReverseMap();

            //CreateMap<BankAccountDTO, BankAccount>().ReverseMap();

        }
    }
}
