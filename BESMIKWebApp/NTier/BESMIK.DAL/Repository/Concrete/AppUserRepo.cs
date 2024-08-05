using BESMIK.DAL.Repository.Abstract;
using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Repository.Concrete
{
    //public class AppUserRepo : Repo<AppUser>, IAppUserRepo
    //{
    //    public AppUserRepo(BesmikDbContext dbContext) : base(dbContext)
    //    {
    //    }

    //    public IEnumerable<AppUser> GetActiveList() 
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public override AppUser? Get(int id)
    //    //{
    //    //    return base._dbContext.AppUsers.SingleOrDefault(c=>c.Id==id);
    //    //}
    //    //public override IEnumerable<AppUser> GetAll()
    //    //{
    //    //    return base._dbContext.AppUsers
    //    //        .Include(c=>c.CompanyManagers)
    //    //        .Include(c=>c.Company)
    //    //        .ToList()
    //    //}

    //}
}
