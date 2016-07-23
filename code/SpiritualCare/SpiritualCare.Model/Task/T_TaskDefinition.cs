using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Task
{
    public class T_TaskDefinition:ModelBase
    {
        [Required]
        [MaxLength(20)]
        [Index(IsUnique =true)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int DueDays { get; set; }
    }
}
