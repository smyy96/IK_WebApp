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
    public class AdvanceProfile : Profile
    {
        public AdvanceProfile()
        {
            CreateMap<AdvanceDto, Advance>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Advance, AdvanceDto>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<AppUserDto, AppUser>().ReverseMap();

        }
    }
}
