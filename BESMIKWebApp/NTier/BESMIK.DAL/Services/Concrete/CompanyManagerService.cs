using BESMIK.DAL.Repository.Abstract;
using BESMIK.DAL.Repository.Concrete;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Services.Concrete
{
    //public class CompanyManagerService : Service<CompanyManager, AccountUserDto>, ICompanyManagerService
    public class CompanyManagerService : Service<CompanyManager, CompanyManagerDto>, ICompanyManagerService
    {
        public CompanyManagerService(CompanyManagerRepo repo) : base(repo)
        {
        }

        //public AccountUserDto? FindLoginUser(string username, string password)
        //{
        //    CompanyManager? companyManager = (base._repo as ICompanyManagerRepo).FindLoginUser(username, password);

        //    return _mapper.Map<AccountUserDto>(companyManager);
        //}
    }
}
