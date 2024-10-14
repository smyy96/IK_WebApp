using AutoMapper;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.AppUser;
using BESMIK.ViewModel.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Profiles
{
    public class PermissionProfile : Profile
    {

        public PermissionProfile()
        {
            CreateMap<PermissionDto, PermissionViewModel>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            CreateMap<PermissionViewModel, PermissionDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            //CreateMap<PermissionDto, PermissionViewModel>().ReverseMap();


            CreateMap<AppUserDto, AppUserViewModel>().ReverseMap();

        }
    }
}
