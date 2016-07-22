using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Activity.CareContact
{
    public class CareContactPerson:ModelBase
    {
        [Required]
        [Index("IDX_CareContact_Person", IsUnique = true, Order =1)]
        public long CareContactID { get; set; }
        [Index("IDX_CareContact_Person", IsUnique = true, Order = 2)]
        [Required]
        public long PersonID { get; set; }
    }
}
