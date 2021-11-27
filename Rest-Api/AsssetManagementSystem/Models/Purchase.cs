using System;
using System.Collections.Generic;

namespace AsssetManagementSystem.Models
{
    public partial class Purchase
    {
        public int PdId { get; set; }
        public string PdOrderNo { get; set; }
        public int PdAdId { get; set; }
        public int PdTypeId { get; set; }
        public int PdQty { get; set; }
        public int PdVendorId { get; set; }
        public DateTime PdDate { get; set; }
        public DateTime PdDdate { get; set; }
        public string PdStatus { get; set; }

        public virtual AssetDefinition PdAd { get; set; }
        public virtual AssetType PdType { get; set; }
        public virtual Vendor PdVendor { get; set; }
    }
}
