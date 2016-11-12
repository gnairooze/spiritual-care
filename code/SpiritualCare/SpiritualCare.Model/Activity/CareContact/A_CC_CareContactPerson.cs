using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Activity.CareContact
{
    public class A_CC_CareContactPerson:ModelBase
    {
        [Required]
        [Index("IDX_CareContact_Person", IsUnique = true, Order =1)]
        public long CareContact_ID { get; set; }
        [Index("IDX_CareContact_Person", IsUnique = true, Order = 2)]
        [Required]
        public long Person_ID { get; set; }
        public DateTime Last_Confession_Date { get; set; }
        public DateTime Last_Communion_Date { get; set; }
    }
}
