using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class Facebook:ContactWay
    {
        [Required]
        [Index]
        public bool IsDefault { get; set; }
    }
}
