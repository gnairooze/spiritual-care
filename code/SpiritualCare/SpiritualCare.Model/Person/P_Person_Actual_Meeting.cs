using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class P_Person_Actual_Meeting:ModelBase
    {
        [Required]
        [Index]
        public long Person_ID { get; set; }
        [Required]
        [MaxLength(20)]
        [Index]
        public string Church { get; set; }
        [Required]
        [MaxLength(20)]
        [Index]
        public string MeetingName { get; set; }
        public string Comment { get; set; }
    }
}
