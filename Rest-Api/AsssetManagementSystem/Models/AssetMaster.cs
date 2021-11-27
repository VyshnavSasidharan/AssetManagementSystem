using System;
using System.Collections.Generic;

namespace AsssetManagementSystem.Models
{
    public partial class AssetMaster
    {
        public int AmId { get; set; }
        public int AmAtypeId { get; set; }
        public int AmMakeId { get; set; }
        public int AmAdId { get; set; }
        public string AmModel { get; set; }
        public string AmSnumber { get; set; }

        public virtual AssetDefinition AmAd { get; set; }
        public virtual AssetType AmAtype { get; set; }
        public virtual Vendor AmMake { get; set; }
    }
}
