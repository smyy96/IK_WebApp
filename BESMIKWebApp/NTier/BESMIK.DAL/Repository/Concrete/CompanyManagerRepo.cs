using BESMIK.DAL.Repository.Abstract;
using BESMIK.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Repository.Concrete
{
    public class CompanyManagerRepo : Repo<CompanyManager>, ICompanyManagerRepo
    {
        public CompanyManagerRepo(BesmikDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CompanyManager> GetActiveList()
        {
            throw new NotImplementedException();
        }

        public override CompanyManager? Get(int id)
        {
            return base._dbContext.CompanyManagers.Include(c => c.Name).SingleOrDefault(c => c.Id == id);
        }
    }

}
