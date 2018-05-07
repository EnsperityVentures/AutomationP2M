using System;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_Entities
{
    public class OmanAmount
    {
        public int ID { get; set; }
        public double? PaymentstoOman { get; set; }
        public double? TotalRemainingAmount { get; set; }
        public DateTime? Dateofpayment { get; set; }
    }
}
