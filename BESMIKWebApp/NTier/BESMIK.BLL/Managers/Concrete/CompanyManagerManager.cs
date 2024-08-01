using BESMIK.BLL.Managers.Abstract;
using BESMIK.DTO;
using BESMIK.ViewModel.CompanyManager;
using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BESMIK.DAL.Services.Concrete;

namespace BESMIK.BLL.Managers.Concrete
{
    public class CompanyManagerManager : Manager<CompanyManagerDto, CompanyManagerViewModel, BESMIK.Entities.Concrete.CompanyManager>
    {
        public CompanyManagerManager(CompanyManagerService service) : base(service)
        {
        }
    }
}
