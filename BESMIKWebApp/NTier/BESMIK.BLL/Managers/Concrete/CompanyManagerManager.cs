using BESMIK.BLL.Managers.Abstract;
using BESMIK.ViewModel.CompanyManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Concrete
{
    public class CompanyManagerManager : Manager<CompanyManagerDto, CompanyManagerViewModel, CompanyManager>
    {
        public CompanyManagerManager(CompanyManager service) : base(service)
        {
        }
    }
}
