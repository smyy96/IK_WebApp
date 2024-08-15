using AutoMapper;
using BESMIK.DTO;
using BESMIK.ViewModel.Advance;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Spending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Profiles
{
    public class AdvanceProfile : Profile
    {
        public AdvanceProfile()
        {
            CreateMap<AdvanceDto, AdvanceViewModel>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            CreateMap<AdvanceViewModel, AdvanceDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            //CreateMap<SpendingDto, SpendingViewModel>().ReverseMap();

            CreateMap<AppUserDto, AppUserViewModel>().ReverseMap();

        }
    }
}
