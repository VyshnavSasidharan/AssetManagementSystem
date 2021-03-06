using System;
using System.Collections.Generic;

namespace AsssetManagementSystem.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            AssetMaster = new HashSet<AssetMaster>();
            Purchase = new HashSet<Purchase>();
        }

        public int VdId { get; set; }
        public string VdName { get; set; }
        public string VdType { get; set; }
        public int VdAtypeId { get; set; }
        public DateTime VdFrom { get; set; }
        public DateTime VdTo { get; set; }
        public string VdAddr { get; set; }

        public virtual AssetType VdAtype { get; set; }
        public virtual ICollection<AssetMaster> AssetMaster { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
