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
        }
    }
}