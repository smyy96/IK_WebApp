using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.ViewModel.Spending
{
    public class SpendingViewModel:BaseViewModel
    {
        public SpendingType SpendingType { get; set; }
        public float Sum { get; set; }
        public SpendingCurrency SpendingCurrency { get; set; }
        public SpendingStatus SpendingStatus { get; set; }
        public DateOnly SpendingRequestDate { get; set; }
        public DateOnly? SpendingResponseDate { get; set; }

        public string? SpendingFile { get; set; }
        public IFormFile? Picture { get; set; }


        public int AppUserId { get; set; }
        public AppUserViewModel? AppUser { get; set; }
    }
}
