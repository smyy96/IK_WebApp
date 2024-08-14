using BESMIK.BLL.Managers.Abstract;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Concrete;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Concrete
{
    public class PermissionManager : Manager<PermissionDto, PermissionViewModel, Permission>
    {
        public PermissionManager(PermissionService service ) : base(service)
        {
        }
    }
}
