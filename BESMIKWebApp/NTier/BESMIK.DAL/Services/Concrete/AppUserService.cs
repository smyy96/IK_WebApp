using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using BESMIK.DAL.Repository.Abstract;
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
    public class AppUserService : Service<AppUser, AppUserDto>
    {
        public AppUserService(AppUserRepo repo) : base(repo)
        {
        }

        public IEnumerable<AppUserDto> GetActiveList()
        {
            IEnumerable<AppUser> appuser = ((IAppUserRepo)base._repo).GetActiveList();

            return _mapper.Map<IEnumerable<AppUserDto>>(appuser);
        }
    }
}
