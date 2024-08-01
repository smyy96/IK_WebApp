using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.DTO
{
    //Sanırım Id çalışanın Id'si olarak düşünülebilir.
    public class BaseDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
    }
}
