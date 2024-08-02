using BESMIK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DTO
{
    public class CompanyManagerDto : BaseDto
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string? Photo { get; set; }
        public DateOnly BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TC { get; set; }
        public DateOnly WorkStartDate { get; set; }
        public Department Department { get; set; }

        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }

    }
}
