using AutoMapper;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Services.Profiles
{
    public class SpendingProfile: Profile
    {
        public SpendingProfile()
        {
            CreateMap<SpendingDto, Spending>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            CreateMap<Spending, SpendingDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            //CreateMap<SpendingDto, Spending>().ReverseMap();

            CreateMap<AppUser, AppUserDto>().ReverseMap();

        }
    }
}
