using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritualCare.Model.Activity.CareContact
{
    public class CareContactServant:ModelBase
    {
        [Required]
        [Index("IDX_CareContact_Servant", IsUnique = true, Order = 1)]
        public long CareContact_ID { get; set; }
        [Required]
        [Index("IDX_CareContact_Servant", IsUnique = true, Order = 2)]
        public long Servant_ID { get; set; }
    }
}
