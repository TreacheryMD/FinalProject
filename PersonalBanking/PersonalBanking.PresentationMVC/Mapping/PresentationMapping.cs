﻿using AutoMapper;
using PersonalBanking.BLL.DTO;
using PersonalBanking.PresentationMVC.Models;

namespace PersonalBanking.PresentationMVC.Mapping
{
    public class PresentationMapping : Profile
    {
        public PresentationMapping()
        {
            CreateMap<UserDTO, UserViewModel>().ReverseMap();
            CreateMap<BankAccountDTO, BankAccountViewModel>()
                .Include<CurrentAccountDTO,BankAccountViewModel>()
                .Include<DepositAccountDTO,BankAccountViewModel>()
                .Include<CreditAccountDTO,BankAccountViewModel>()
                .ForMember(dest => dest.FiscalCode, opt => opt.MapFrom(src => src.Person.FiscalCode));
            
            CreateMap<CurrentAccountDTO, BankAccountViewModel>();
            CreateMap<DepositAccountDTO, BankAccountViewModel>();
            CreateMap<CreditAccountDTO, BankAccountViewModel>();

   

            CreateMap<BankAccountViewModel, BankAccountDTO>();

            //CreateMap<BankAccountViewModel, BankAccountDTO>()
            //    .Include<BankAccountViewModel, CurrentAccountDTO>()
            //    .Include<BankAccountViewModel, DepositAccountDTO>()
            //    .Include<BankAccountViewModel, CreditAccountDTO>();

            //CreateMap<BankAccountViewModel, CreditAccountDTO>();
            //CreateMap<BankAccountViewModel, CurrentAccountDTO>();
            //CreateMap<BankAccountViewModel, DepositAccountDTO>();

            CreateMap<BankAccountViewModel, BankAccountDTO>()
                .ConvertUsing<CustomBankAccountConverter>();

            CreateMap<CurrentAccountViewModel, CurrentAccountDTO>().ReverseMap();
            CreateMap<DepositAccountViewModel, DepositAccountDTO>().ReverseMap();
            CreateMap<CreditAccountViewModel, CreditAccountDTO>().ReverseMap();

            CreateMap<PersonDTO, PersonViewModel>().ReverseMap();
        }
    }

    public class CustomBankAccountConverter : ITypeConverter<BankAccountViewModel, BankAccountDTO>
    {
        public BankAccountDTO Convert(BankAccountViewModel source, BankAccountDTO destination, ResolutionContext context)
        {
            BankAccountDTO dtoResult = null;
            if (source.AccNum.Substring(source.AccNum.Length - 2).Contains("CR"))
            {
                var vSource = new CurrentAccountViewModel() {AccNum = source.AccNum,Balance = source.Balance,Currency = source.Currency,Id = source.Id,OpenDate = source.OpenDate,Restricted = source.Restricted}; 
                dtoResult = Mapper.Map<CurrentAccountViewModel, CurrentAccountDTO>(vSource);
            }
            if (source.AccNum.Contains("CRED"))
            {
                var vSource = new CreditAccountViewModel() { AccNum = source.AccNum, Balance = source.Balance, Currency = source.Currency, Id = source.Id, OpenDate = source.OpenDate,Rate = source.Rate,Reimbursement = source.Reimbursement};
                dtoResult = Mapper.Map<CreditAccountViewModel, CreditAccountDTO>(vSource);
            }
            if (source.AccNum.Contains("DEP"))
            {
                var vSource = new DepositAccountViewModel() { AccNum = source.AccNum, Balance = source.Balance, Currency = source.Currency, Id = source.Id, OpenDate = source.OpenDate,DepIntRate = source.DepIntRate};
                dtoResult = Mapper.Map<DepositAccountViewModel,DepositAccountDTO>(vSource);
            }
            return dtoResult;
        }
    }
}