﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class ContactWay:ModelBase
    {
        [Required]
        [Index]
        public long Person_ID { get; set; }
        [Required]
        [MaxLength(20)]
        [Index]
        public string ContactType { get; set; }
        [Required]
        [MaxLength(50)]
        public string Value { get; set; }
        public string Comment { get; set; }
    }
}
