using AutoMapper;
using BESMIK.BLL.Managers.Abstract;
using BESMIK.DAL;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Concrete;
using BESMIK.DAL.Services.Profiles;
using BESMIK.DTO;
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
    public class SpendingManager : Manager<SpendingDto, SpendingViewModel, BESMIK.Entities.Concrete.Spending>
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

        public override IEnumerable<SpendingViewModel> GetAll()
        {
            var dtos = _service.GetAll();
            return _mapper.Map<IEnumerable<SpendingViewModel>>(dtos);
        }

        public IEnumerable<SpendingViewModel> GetManagersBySpendingID(int spendingId)
        {
            var appUserWithSpendings = _context.AppUsers
                .Include(c => c.Spendings)
                .FirstOrDefault(c => c.Id == spendingId);

            if (appUserWithSpendings == null)
            {
                return new List<SpendingViewModel>();
            }

            var spendings = appUserWithSpendings.Spendings;

            var spendingViewModels = spendings.Select(cm => new SpendingViewModel
            {
                Id = cm.Id,
                Sum= cm.Sum,
                SpendingRequestDate= cm.SpendingRequestDate,
                SpendingResponseDate= cm.SpendingResponseDate,
                SpendingFile = cm.SpendingFile,
                SpendingCurrency = cm.SpendingCurrency,
                SpendingStatus= cm.SpendingStatus,
                SpendingType= cm.SpendingType
            }).ToList();

            return spendingViewModels;
        }
    }
}
