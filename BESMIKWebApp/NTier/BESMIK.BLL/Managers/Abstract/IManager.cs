using AutoMapper;
using BESMIK.DTO;
using BESMIK.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Abstract
{
    public interface IManager<TDto, TViewModel>
        where TDto : BaseDto
        where TViewModel : BaseViewModel
    {
        IMapper Mapper { set; }
        int Add(TViewModel viewmodel);
        int Update(TViewModel viewmodel);
        int Delete(TViewModel viewmodel);
        int Delete(int id);
        IEnumerable<TViewModel> GetAll();
        TViewModel? Get(int id);
    }
}
