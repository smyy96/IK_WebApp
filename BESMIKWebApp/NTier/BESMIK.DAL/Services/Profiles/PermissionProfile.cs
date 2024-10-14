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
    public class PermissionProfile : Profile
    {

        public PermissionProfile()
        {
            CreateMap<PermissionDto, Permission>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            CreateMap<Permission, PermissionDto>().ForMember(dest => dest.AppUser, opt => opt.MapFrom(src => src.AppUser));

            //CreateMap<PermissionDto, Permission>().ReverseMap();

            CreateMap<AppUser, AppUserDto>().ReverseMap();

        }

    }
}
