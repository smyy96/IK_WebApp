using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DTO;
using BESMIK.Entities.Abstract;
using BESMIK.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.BLL.Managers.Abstract
{
    public abstract class Manager<TDto, TViewModel, TEntity> : IManager<TDto, TViewModel>
       where TDto : BaseDto
       where TEntity : BaseEntity
       where TViewModel : BaseViewModel
    {
        protected Service<TEntity, TDto> _service;
        protected IMapper _mapper;

        protected Manager(Service<TEntity, TDto> service)
        {
            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().AddCollectionMappers();
                cfg.CreateMap<TDto, TViewModel>().ReverseMap();
            });

            _mapper = _config.CreateMapper();

            _service = service;
        }

        public IMapper Mapper
        {
            set { _mapper = value; }
        }

        public int Add(TViewModel viewModel)
        {
            TDto dto = _mapper.Map<TDto>(viewModel);

            return _service.Add(dto);
        }

        public int Delete(TViewModel viewModel)
        {
            TDto dto = _mapper.Map<TDto>(viewModel);

            return _service.Delete(dto);
        }

        public int Delete(int id)
        {
            return _service.Delete(id);
        }

        public TViewModel? Get(int id)
        {
            TDto? dto = _service.Get(id);

            return _mapper.Map<TViewModel>(dto);
        }

        public virtual IEnumerable<TViewModel> GetAll()
        {
            IEnumerable<TDto> list = _service.GetAll().ToList();

            return _mapper.Map<IEnumerable<TViewModel>>(list);
        }

        public int Update(TViewModel viewModel)
        {
            TDto dto = _mapper.Map<TDto>(viewModel);

            return _service.Update(dto);
        }
    }
}
