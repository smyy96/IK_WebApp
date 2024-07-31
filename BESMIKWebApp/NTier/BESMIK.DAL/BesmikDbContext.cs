using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL
{
    public class BesmikDbContext:DbContext
    {
        public BesmikDbContext(DbContextOptions<BesmikDbContext> options)
    : base(options)
        {

        }

    }
}
