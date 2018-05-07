using System;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_Entities
{
    public class OmanFloat
    {
        //public int? ID { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public string MemberName { get; set; }
        public double? PaymentstoOman { get; set; }
        public double? Totalcost { get; set; }
        public double? Deliveryfees { get; set; }
        public double? TotalCostwithDelivery { get; set; }
        public double? TotalRemainingAmount { get; set; }
        public string Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string CardTypeandAmount { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Dateofpayment { get; set; }



    }
}
