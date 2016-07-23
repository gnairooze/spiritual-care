using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Person
{
    public class P_Person:ModelBase
    {
        [MaxLength(10)]
        public string Title { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string MiddleName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(60)]
        [Required]
        public string FamilyName { get; set; }
        [MaxLength(20)]
        public string FamilyRole { get; set; }
        [MaxLength(900)]
        public byte[] Photo { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public bool IsMale { get; set; }
        [MaxLength(20)]
        public string NationalID { get; set; }
        [MaxLength(20)]
        public string SocialStatus { get; set; }
        public string Comment { get; set; }
        [MaxLength(20)]
        public string Church { get; set; }
        [MaxLength(20)]
        public string Diocese { get; set; }
        [MaxLength(60)]
        public string ConfessionFather { get; set; }
        [MaxLength(60)]
        public string ServantInChurchService { get; set; }
        [Required]
        public bool IsLordBrother { get; set; }
    }
}
