using BESMIK.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Services.Abstract
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetActiveList();
    }
}
