﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Services.Abstract
{
    public interface ICompanyManagerService
    {
        AccountUserDto? FindLoginUser(string username, string password);

    }
}
