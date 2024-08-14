//using BESMIK.DAL.Repository.Abstract;
//using BESMIK.Entities.Concrete;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Metrics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BESMIK.DAL.Repository.Concrete
//{
//    public class AppUserRepo : Repo<AppUser>, IAppUserRepo
//    {
//        public AppUserRepo(BesmikDbContext dbContext) : base(dbContext)
//        {
//        }

//        public IEnumerable<AppUser> GetActiveList()
//        {
//            throw new NotImplementedException();
//        }

//        public override AppUser? Get(int id)
//        {
//            return base._dbContext.AppUsers.SingleOrDefault(c => c.Id == id);

//        }
//    }
//}
