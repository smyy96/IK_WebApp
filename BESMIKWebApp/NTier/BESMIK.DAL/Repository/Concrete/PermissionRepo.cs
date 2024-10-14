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
    public class PermissionRepo : Repo<Permission>
    {
        public PermissionRepo(BesmikDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Permission> GetActiveList()
        {
            throw new NotImplementedException();
        }
        public override Permission? Get(int id)
        {
            return base._dbContext.Permissions.SingleOrDefault(c => c.Id == id);
        }
        public override IEnumerable<Permission> GetAll()
        {
            return base._dbContext.Permissions
                .Include(c => c.AppUser)
                .ToList();
        }

    }
}
