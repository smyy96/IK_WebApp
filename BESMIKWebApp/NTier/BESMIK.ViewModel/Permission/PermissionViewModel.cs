using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.ViewModel.Permission
{
    public class PermissionViewModel : BaseViewModel
    {
        public DateOnly PermissionStartDate { get; set; }
        public DateOnly PermissionEndDate { get; set; }
        public string OffDaysNumbers { get; set; }
        public PermissionType PermissionType { get; set; }
        public PermissionStatus PermissionStatus { get; set; }

        public DateOnly PermissionRequestDate { get; set; }
        public DateOnly? PermissionResponseDate { get; set; }

        public int AppUserId { get; set; }
        public AppUserViewModel? AppUser { get; set; }
    }
}
