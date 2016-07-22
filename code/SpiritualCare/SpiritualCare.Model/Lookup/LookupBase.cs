using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Lookup
{
    public class LookupBase:ModelBase
    {
        [Required]
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
