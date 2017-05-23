using AutoMapper;
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

            CreateMap<CurrentAccountViewModel, CurrentAccountDTO>();
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
                //var vSource = source as CurrentAccountViewModel;
                dtoResult = Mapper.Map<CurrentAccountViewModel, CurrentAccountDTO>(vSource);
            }
            if (source.AccNum.Contains("CRED"))
            {
                var vSource = new () { AccNum = source.AccNum, Balance = source.Balance, Currency = source.Currency, Id = source.Id, OpenDate = source.OpenDate, Restricted = source.Restricted };
                //var vSource = source as CurrentAccountViewModel;
                dtoResult = Mapper.Map<CurrentAccountViewModel, CurrentAccountDTO>(vSource);
            }
            return dtoResult;
        }
    }
}