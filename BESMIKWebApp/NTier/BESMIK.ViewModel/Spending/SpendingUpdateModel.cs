using BESMIK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.ViewModel.Spending
{
    public class SpendingUpdateModel
    {
        public int Id { get; set; }
        public SpendingStatus SpendingStatus { get; set; }
        public string AppUserId { get; set; }  
    }
}
