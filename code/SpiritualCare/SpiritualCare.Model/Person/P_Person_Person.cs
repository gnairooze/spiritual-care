using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class P_Person_Person:ModelBase
    {
        [Required]
        public long FromPerson_ID { get; set; }
        [Required]
        public long ToPerson_ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string RelationType { get; set; }
        public string Comment { get; set; }
    }
}
