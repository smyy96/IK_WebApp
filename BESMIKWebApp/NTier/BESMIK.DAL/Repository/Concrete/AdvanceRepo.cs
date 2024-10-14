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
    public class AdvanceRepo : Repo<Advance>
    {
        public AdvanceRepo(BesmikDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Advance> GetActiveList()
        {
            throw new NotImplementedException();
        }
        public override Advance? Get(int id)
        {
            return base._dbContext.Advances.SingleOrDefault(c => c.Id == id);
        }
        public override IEnumerable<Advance> GetAll()
        {
            return base._dbContext.Advances
                .Include(c => c.AppUser)
                .ToList();
        }
    }
}
