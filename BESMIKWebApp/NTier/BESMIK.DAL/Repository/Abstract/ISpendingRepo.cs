using BESMIK.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DAL.Repository.Abstract
{
    public interface ISpendingRepo
    {
        IEnumerable<Spending> GetActiveList();
    }
}
