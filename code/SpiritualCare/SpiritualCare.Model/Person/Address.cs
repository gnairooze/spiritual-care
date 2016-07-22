using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class Address:ModelBase
    {
        [Required]
        [MaxLength(20)]
        public string AddressType { get; set; }
        [MaxLength(4)]
        public string StreetNo { get; set; }
        [Required]
        [MaxLength(90)]
        [Index]
        public string StreetName { get; set; }
        [Required]
        [MaxLength(20)]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        public string Governerate { get; set; }
        [Required]
        [MaxLength(20)]
        public string Country { get; set; }
        public string Comment { get; set; }
        [Required]
        [Index]
        public bool IsDefault { get; set; } 
        public double GPS_Long { get; set; }
        public double GPS_Lat { get; set; }
    }
}
