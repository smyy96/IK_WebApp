using BESMIK.Common;
using BESMIK.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.Entities.Concrete
{
    public class Spending : BaseEntity
    {
        public SpendingType SpendingType { get; set; }
        public float Sum { get; set; }
        public SpendingCurrency SpendingCurrency { get; set; }
        public SpendingStatus SpendingStatus { get; set; }
        public DateOnly SpendingRequestDate { get; set; }
        public DateOnly? SpendingResponseDate { get; set; }
        public string? SpendingFile { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


    }
}
