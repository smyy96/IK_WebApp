using BESMIK.Common;
using BESMIK.Entities.Abstract;
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
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string? Photo {  get; set; }
        public DateOnly BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string Tc {  get; set; }
        public DateOnly WorkStartDate {  get; set; }
        public DateOnly? WorkEndDate {  get; set; }
        public bool IsActive { get; set; }
        public string Job {  get; set; }
        public Department Department {  get; set; }
        public string? PersonalEmail { get; set; } //Sahıs maili kullanıcının normal mail adresi identityden geliyor
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public float? Wage { get; set; } //maas bilgisi


        public int? CompanyId { get; set; }
        public Company Company { get; set; }



        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Spending> Spendings { get; set; }
        public ICollection<Advance> Advances { get; set; }


    }
}
