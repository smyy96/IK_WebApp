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
        public string? Photo { get; set; }
        public DateOnly BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TC { get; set; }
        public DateOnly WorkStartDate { get; set; }
        public Department Department { get; set; }

        public ICollection<Companies> Companies { get; set; } //= new List<Companies>();
    }
}
