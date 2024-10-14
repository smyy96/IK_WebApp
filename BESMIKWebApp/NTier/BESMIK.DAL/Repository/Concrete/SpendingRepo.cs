using BESMIK.DAL.Repository.Abstract;
using BESMIK.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Repository.Concrete
{
    public class SpendingRepo : Repo<Spending>
    {
        public SpendingRepo(BesmikDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Spending> GetActiveList()
        {
            throw new NotImplementedException();
        }

        public override Spending? Get(int id)
        {
            return base._dbContext.Spendings.SingleOrDefault(c => c.Id == id);
        }

        public override IEnumerable<Spending> GetAll()
        {
            return base._dbContext.Spendings
                .Include(c => c.AppUser)
                .ToList();
        }
    }
}
