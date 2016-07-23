using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Task
{
    public class T_TaskPerson:ModelBase
    {
        [Required]
        [Index("IDX_Task_Person", IsUnique =true, Order =1)]
        public long Task_ID { get; set; }
        [Required]
        [Index("IDX_Task_Person", IsUnique = true, Order = 2)]
        public long Person_ID { get; set; }
    }
}
