using BESMIK.Common;
using BESMIK.ViewModel.Company;
using Microsoft.AspNetCore.Http;
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
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }


        public string? Photo { get; set; }
        public byte[]? PictureFile { get; set; }
        public IFormFile? FormFile { get; set; }

        public string Address { get; set; }
        public DateOnly BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TC { get; set; }
        public DateOnly WorkStartDate { get; set; }
        public Department Department { get; set; }

        public int CompanyId { get; set; }
        public CompanyViewModel? Company { get; set; }
    }
}
