using BESMIK.BLL.Managers.Abstract;
using BESMIK.DAL.Services.Concrete;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Concrete
{
    public class CompanyManager : Manager<CompanyDto, CompanyViewModel, Company>
    {
        public CompanyManager(CompanyService service) : base(service)
        {
        }
    }
}
