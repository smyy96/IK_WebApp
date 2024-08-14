using BESMIK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DTO
{
    public class SpendingDto:BaseDto
    {
        public SpendingType SpendingType { get; set; }
        public float Sum { get; set; }
        public SpendingCurrency SpendingCurrency { get; set; }
        public SpendingStatus SpendingStatus { get; set; }
        public DateOnly SpendingRequestDate { get; set; }
        public DateOnly? SpendingResponseDate { get; set; }
        public string? SpendingFile { get; set; }


        public int AppUserId { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
