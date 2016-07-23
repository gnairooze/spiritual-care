using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class P_WhatsApp:ContactWay
    {
        [Required]
        [Index]
        public bool IsDefault { get; set; }
    }
}
