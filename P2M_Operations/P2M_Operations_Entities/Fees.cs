using System;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_Entities
{
    public class Fees
    {
        public int? ID { get; set; }
        public string RewardName { get; set; }
        public Double ShippingCost { get; set; }
        public Double HandlingCost { get; set; }
        public Double ServiceCharge { get; set; }
        public Double? Total { get; set; }
        public string SKU { get; set; }


    }
}
