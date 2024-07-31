using BESMIK.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Photo {  get; set; }
        public DateOnly BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Tc {  get; set; }
        public DateOnly WorkStartDate {  get; set; }
        public DateOnly WorkEndDate {  get; set; }
        public bool IsActive { get; set; }
        public string Job {  get; set; }
        public Department Department {  get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        
    }
}
