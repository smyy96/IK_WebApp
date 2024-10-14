
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
    public class CompanyRepo : Repo<Company>//, ICompanyRepo
    {
        public CompanyRepo(BesmikDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Company> GetActiveList()
        {
            throw new NotImplementedException();
        }
        public override Company? Get(int id)
        {
            return base._dbContext.Companies.SingleOrDefault(c => c.Id == id);
        }

    }
}
