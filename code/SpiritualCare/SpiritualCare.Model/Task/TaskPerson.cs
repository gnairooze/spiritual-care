using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Task
{
    public class TaskPerson:ModelBase
    {
        [Required]
        [Index("IDX_Task_Person", IsUnique =true, Order =1)]
        public long TaskID { get; set; }
        [Required]
        [Index("IDX_Task_Person", IsUnique = true, Order = 2)]
        public long PersonID { get; set; }
    }
}
