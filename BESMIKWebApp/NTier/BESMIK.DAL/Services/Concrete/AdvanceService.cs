using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using BESMIK.DAL.Repository.Concrete;
using BESMIK.DAL.Services.Abstract;
using BESMIK.DAL.Services.Profiles;
using BESMIK.DTO;
using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Services.Concrete
{
    public class AdvanceService : Service<Advance, AdvanceDto>
    {
        public AdvanceService(AdvanceRepo repo) : base(repo)
        {
            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().AddCollectionMappers();
                cfg.AddProfile<AdvanceProfile>();
            });

            base._mapper = _config.CreateMapper();
        }
    }
}
