using BESMIK.Common;
using BESMIK.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.Entities.Concrete
{
    public class Advance : BaseEntity
    {
        public DateOnly AdvanceRequestDate { get; set; } // Talep Tarihi
        public AdvanceApprovalStatus ApprovalStatus { get; set; } // Onay Durumu
        public DateOnly? AdvanceResponseDate { get; set; } // Cevaplanma Tarihi
        public float Amount { get; set; } // Tutarı
        public AdvanceCurrency Currency { get; set; } // Para Birimi
        public string Description { get; set; } // Açıklaması
        public AdvanceType AdvanceType { get; set; } //Türü

       
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
