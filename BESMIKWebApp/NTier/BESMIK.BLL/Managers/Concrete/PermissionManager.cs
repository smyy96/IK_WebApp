using AutoMapper;
using BESMIK.BLL.Managers.Abstract;
using BESMIK.BLL.Managers.Profiles;
using BESMIK.DAL;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Concrete;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using BESMIK.ViewModel.Permission;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Concrete
{
    public class PermissionManager : Manager<PermissionDto, PermissionViewModel, Permission>
    {
        private readonly BesmikDbContext _context;
        public PermissionManager(PermissionService service, BesmikDbContext context) : base(service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PermissionProfile>();

            });
            _context = context;

            base._mapper = config.CreateMapper();
        }
    }
}
