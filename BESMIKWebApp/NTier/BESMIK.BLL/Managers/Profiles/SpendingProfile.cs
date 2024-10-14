using AutoMapper;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Spending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Profiles
{
    public class SpendingProfile: Profile
    {
        public SpendingProfile()
        {
            CreateMap<SpendingDto, SpendingViewModel>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            CreateMap<SpendingViewModel, SpendingDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            //CreateMap<SpendingDto, SpendingViewModel>().ReverseMap();

            CreateMap<AppUserDto, AppUserViewModel>().ReverseMap();

        }
    }
}
