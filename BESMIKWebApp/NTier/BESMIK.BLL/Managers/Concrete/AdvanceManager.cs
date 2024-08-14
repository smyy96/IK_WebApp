using BESMIK.BLL.Managers.Abstract;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Concrete;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Advance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Concrete
{
    public class AdvanceManager : Manager<AdvanceDto, AdvanceViewModel, Advance>
    {
        public AdvanceManager(AdvanceService service) : base(service)
        {
        }
    }
}
