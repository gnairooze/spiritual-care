using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model
{
    public class ModelBase
    {
        [Key]
        public long ID { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Modified { get; set; }
    }
}
