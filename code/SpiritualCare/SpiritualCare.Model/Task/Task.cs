using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Task
{
    public class Task:ModelBase
    {
        [Required]
        public long TaskDefinition_ID { get; set; }
        public long CareContact_ID { get; set; }
        [Required]
        [MaxLength(70)]
        public string FamilyName { get; set; }
        public string Comment { get; set; }
        [Required]
        [MaxLength(20)]
        [Index]
        public string Status { get; set; }
        [Required]
        [Index]
        public DateTime DueDate { get; set; }
    }
}
