using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class Person_Job:ModelBase
    {
        [Required]
        [Index("IDX_Person_Job", IsUnique = true, Order = 1)]
        public long Person_ID { get; set; }
        [Required]
        [Index("IDX_Person_Job", IsUnique = true, Order = 2)]
        public long Job_ID { get; set; }
    }
}
