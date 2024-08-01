using BESMIK.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.ViewModel.CompanyManager
{
    public class CompanyManagerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }


        public string? Photo { get; set; }
        public byte[]? PictureFile { get; set; }


        public DateOnly BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TC { get; set; }
        public DateOnly WorkStartDate { get; set; }
        public Department Department { get; set; }

        public int CompanyId { get; set; }
    }
}
