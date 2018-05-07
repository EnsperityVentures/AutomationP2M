using System;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_Entities
{
    public class ClientsDailyOrders
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public string PIN { get; set; }
        public string EmployeeID { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string CatalogName { get; set; }
        public string RewardName { get; set; }
        public int? Quantity { get; set; }
        public string Details { get; set; }
        public string HighestLevelCategory { get; set; }
        public string LowestLevelCategory { get; set; }
        public string ShipToCompany { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToCountry { get; set; }
        public string P2MOrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string CurrentStatus { get; set; }
        public string DiscountCoupon { get; set; }
        public string RedemptionAmount { get; set; }
        public string DiscountApplied { get; set; }
        public string MemberPaid { get; set; }
        public double? PointBillingRate { get; set; }
        public DateTime? DateandTime { get; set; }
        //public int? delayed { get; set; }
    }
}
