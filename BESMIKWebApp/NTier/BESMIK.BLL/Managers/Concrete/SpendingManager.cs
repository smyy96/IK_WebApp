using AutoMapper;
using BESMIK.BLL.Managers.Abstract;
using BESMIK.BLL.Managers.Profiles;
using BESMIK.DAL;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Concrete;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
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
        private readonly BesmikDbContext _context;
        public SpendingManager(SpendingService service, BesmikDbContext context) : base(service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SpendingProfile>();

            });
                _context = context;

            base._mapper = config.CreateMapper();
        }
    }
}
