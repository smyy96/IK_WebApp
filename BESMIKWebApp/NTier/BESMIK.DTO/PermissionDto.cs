﻿using BESMIK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DTO
{
    public class PermissionDto : BaseDto
    {
        public DateOnly PermissionStartDate { get; set; }
        public DateOnly PermissionEndDate { get; set; }
        public string OffDaysNumbers { get; set; }
        public PermissionType PermissionType { get; set; }
        public PermissionStatus PermissionStatus { get; set; }
        //public ICollection<AppUserDto> AppUsers { get; set; }
    }
}
