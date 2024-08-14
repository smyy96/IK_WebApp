using AutoMapper;
using BESMIK.BLL.Managers.Abstract;
using BESMIK.DAL;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Concrete;
using BESMIK.DAL.Services.Profiles;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.CompanyManager;
using BESMIK.ViewModel.Spending;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Concrete
{
    public class SpendingManager : Manager<SpendingDto, SpendingViewModel, Spending>
    {
        public SpendingManager(SpendingService service) : base(service)
        {
        }
    }
}
