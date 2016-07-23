using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class P_Job:ModelBase
    {
        [MaxLength(20)]
        [Index]
        public string Profession { get; set; }
        [MaxLength(30)]
        [Index]
        public string JobTitle { get; set; }
        [MaxLength(70)]
        public string Employer { get; set; }
        public string Comment { get; set; }
    }
}
