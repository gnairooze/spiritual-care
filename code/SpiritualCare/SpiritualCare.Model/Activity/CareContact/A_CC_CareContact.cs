using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Activity.CareContact
{
    public class A_CC_CareContact:ModelBase
    {
        [Required]
        public DateTime ContactDate { get; set; }
        [Required]
        [MaxLength(20)]
        public string ContactMean { get; set; }
        [Required]
        [MaxLength(80)]
        public string FamilyName { get; set; }
        public string Comment { get; set; }
    }
}
