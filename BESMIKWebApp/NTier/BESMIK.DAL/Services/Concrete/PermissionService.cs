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
    public class PermissionService : Service<Permission, PermissionDto>
    {
        public PermissionService(PermissionRepo repo) : base(repo)
        {
            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddExpressionMapping().AddCollectionMappers();
                cfg.AddProfile<PermissionProfile>();
            });

            base._mapper = _config.CreateMapper();
        }

        //public AccountUserDto? FindLoginUser(string username, string password)
        //{
        //    CompanyManager? companyManager = (base._repo as ICompanyManagerRepo).FindLoginUser(username, password);

        //    return _mapper.Map<AccountUserDto>(companyManager);
        //}


        public override IEnumerable<PermissionDto> GetAll()
        {
            var permissions = _repo.GetAll();
            return _mapper.Map<IEnumerable<PermissionDto>>(permissions);
        }
    }

}


