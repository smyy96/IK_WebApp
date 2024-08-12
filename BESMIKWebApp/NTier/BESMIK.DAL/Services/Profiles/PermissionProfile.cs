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
            CreateMap<PermissionDto, Permission>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Permission, PermissionDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<AppUserDto, AppUser>().ReverseMap();

        }

    }
}
