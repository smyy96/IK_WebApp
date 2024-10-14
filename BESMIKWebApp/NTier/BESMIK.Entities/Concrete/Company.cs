using BESMIK.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.Entities.Concrete
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string TitleName { get; set; }
        public string MersisNumber { get; set; }
        public string TaxNumber { get; set; }
        public string TaxAdministration { get; set; }

        public string? Logo { get; set; }
        public byte[]? PictureFile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string EmployeesNumber { get; set; }
        public DateOnly EstablishmentYear { get; set; }
        public DateOnly? ContractStartYear { get; set; }
        public DateOnly? ContractEndYear { get; set; }
        public bool IsActive { get; set; }


        public ICollection<AppUser> AppUsers { get; set; }

    }
}
