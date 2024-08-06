using BESMIK.BLL.Managers.Abstract;
using BESMIK.DTO;
using BESMIK.ViewModel.CompanyManager;
using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BESMIK.DAL.Services.Concrete;
using AutoMapper;
using BESMIK.BLL.Managers.Profiles;
using BESMIK.DAL;
using Microsoft.EntityFrameworkCore;

namespace BESMIK.BLL.Managers.Concrete
{
    public class CompanyManagerManager : Manager<CompanyManagerDto, CompanyManagerViewModel, BESMIK.Entities.Concrete.CompanyManager>
    {
        private readonly BesmikDbContext _context;

        public CompanyManagerManager(CompanyManagerService service, BesmikDbContext context) : base(service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CompanyManagerProfile>();

            });
                _context = context;

            base._mapper = config.CreateMapper();
        }

        public override IEnumerable<CompanyManagerViewModel> GetAll()
        {
            var dtos = _service.GetAll();
            return _mapper.Map<IEnumerable<CompanyManagerViewModel>>(dtos);
        }
        public IEnumerable<CompanyManagerViewModel> GetManagersByCompanyID(int companyId)
        {
            var companyWithManagers = _context.Companies
                .Include(c => c.CompanyManagers)
                .FirstOrDefault(c => c.Id == companyId);

            if (companyWithManagers == null)
            {
                return new List<CompanyManagerViewModel>();
            }

            var managers = companyWithManagers.CompanyManagers;

            // Mapleme yapmadan elle dönüşüm işlemi yaptım.
            var managerViewModels = managers.Select(cm => new CompanyManagerViewModel
            {
                Id = cm.Id,
                Name = cm.Name,
                SecondName = cm.SecondName,
                Surname = cm.Surname,
                SecondSurname = cm.SecondSurname,
                Phone = cm.Phone,
                Email = cm.Email,
                Photo = cm.Photo,
                PictureFile = cm.PictureFile,
                BirthDate = cm.BirthDate,
                BirthPlace = cm.BirthPlace,
                TC = cm.TC,
                WorkStartDate = cm.WorkStartDate,
                Department = cm.Department
            }).ToList();

            return managerViewModels;
        }
    }
}
