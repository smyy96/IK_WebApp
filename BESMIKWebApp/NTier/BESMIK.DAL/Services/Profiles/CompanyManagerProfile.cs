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
    public class CompanyManagerProfile : Profile
    {
        public CompanyManagerProfile()
        {
            CreateMap<CompanyManagerDto, CompanyManager>().ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<CompanyManager, CompanyManagerDto>().ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<CompanyManagerDto, CompanyManager>().ReverseMap();
        }
    }
}
