using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DTO
{
    //Buraya Entitites'deki appuser'dan aldığım propları ekledim, hepsine gerek var mı bilmiyorum.
    public class EmployeeDto : BaseDto
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        //public decimal Salary { get; set; } //maaşı prop olarak konulabilir mi yoksa isterlerde yok diye koymaya gerek yok mu

        //public string JobDescription { get; set; } // gerek var mı
        public string? Photo { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string Tc { get; set; }
        public DateOnly WorkStartDate { get; set; }
        public DateOnly? WorkEndDate { get; set; }
        public bool IsActive { get; set; } //çalışanı aktifleştir/pasifleştir
        public string Job { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public int JobCategoryId { get; set; }
        public JobCategoryDto JobCategory { get; set; }

        //Bir de her personelin "Özlük Belgeleri", "İzinleri", "Harcama?'ları", ve "Zimmetleri" olacak şekilde isteniyor sanırım. Bu 4'ü için de JobCategoryDto.cs gibi bir class açmalı mıyız yoksa onları da prop olarak buraya mı ekleyeceğiz onu bilemedim. 

        // Bir de ayriyeten "Vardiya Yönetimi Sayfası" var Şirket Yöneticisine ait. Vardiya oluşturup çalışanlara vardiya ekle güncelle sil işlemlerini verebiliyor ve mola oluşturup ekle güncelle sil işlemlerini verebiliyor. Onun dto ile alakası yok ama sanırım.
    }
}
