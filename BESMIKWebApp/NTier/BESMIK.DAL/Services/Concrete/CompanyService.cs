using AutoMapper;
using BESMIK.DAL.Repository.Abstract;
using BESMIK.DAL.Repository.Concrete;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Profiles;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Services.Concrete
{
    public class CompanyService : Service<Company, CompanyDto>
    {
        public CompanyService(CompanyRepo repo) : base(repo)
        {
        }

        //public CompanyService(CompanyRepo repo) : base(repo)
        //{
        //    MapperConfiguration config = new MapperConfiguration(config =>
        //    {
        //        Profile profile = new CompanyProfile();
        //        config.AddProfile(profile);
        //    });

        //    base.Mapper = config.CreateMapper();
        //}

        public IEnumerable<CompanyDto> GetActiveList()
        {
            IEnumerable<Company> companies = ((ICompanyRepo)base._repo).GetActiveList();

            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

    }
}
