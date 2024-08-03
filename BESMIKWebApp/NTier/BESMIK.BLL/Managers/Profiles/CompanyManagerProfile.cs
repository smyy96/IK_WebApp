using AutoMapper;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Company;
using BESMIK.ViewModel.CompanyManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Profiles
{
    public class CompanyManagerProfile : Profile
    {
        public CompanyManagerProfile()
        {
            CreateMap<CompanyManagerDto, CompanyManagerViewModel>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<CompanyManagerViewModel, CompanyManagerDto>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company));

            CreateMap<CompanyDto, CompanyViewModel>().ReverseMap();
        }
    }


}
