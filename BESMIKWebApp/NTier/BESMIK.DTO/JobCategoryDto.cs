using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DTO
{
    //Burayı çalışanın çalıştığı departman olarak mı düşünelim yoksa çalışanın mesleği mi yoksa farketmez mi bilemedim.
    public class JobCategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
