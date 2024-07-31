using BESMIK.Common;
using BESMIK.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.Entities.Concrete
{
    public class CompanyManager : BaseEntity
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        //public string Address { get; set; }
        public string? Photo { get; set; }
        public DateOnly BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TC { get; set; }
        public DateOnly WorkStartDate { get; set; }
        //public DateOnly WorkEndDate { get; set; }
        //public bool IsActive { get; set; }
        //public string Job { get; set; }
        public Department Department { get; set; }

        //Bir şirketin birden fazla şirket yöneticisi olabilir. Bir şirket yöneticisinin sadece bir şirketi vardır. => 1-n 
        //Buna göre ilişkiler eklenecektir.
    }
}
