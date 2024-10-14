using BESMIK.Common;
using BESMIK.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.Entities.Concrete
{
    public class Permission : BaseEntity
    {
        public PermissionType PermissionType { get; set; }
        public DateOnly PermissionStartDate { get; set; }
        public DateOnly PermissionEndDate { get; set; }
        public DateOnly PermissionRequestDate { get; set; }
        public string OffDaysNumbers { get; set; }
        public PermissionStatus PermissionStatus { get; set; }
        public DateOnly? PermissionResponseDate { get; set; }


        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
