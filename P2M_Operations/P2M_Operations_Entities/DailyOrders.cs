using System;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_Entities
{
    public class DailyOrders
    {
        public string ID { get; set; }
        public string PIN { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string CatalogName { get; set; }
        public string RewardName { get; set; }
        public int? Quantity { get; set; }
        public string Details { get; set; }
        public string HighestLevelCategory { get; set; }
        public string LowestLevelCategory { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string P2MOrderNumber { get; set; }
        public string OrderStatus { get; set; }
        public string OrderCStatus { get; set; }
        public string DiscountCoupon { get; set; }
        public double? RedemptionAmount { get; set; }
        public string DiscountApplied { get; set; }
        public string MemberPaid { get; set; }
        public double? PointBillingRate { get; set; }
        public DateTime? OrderDate { get; set; }
        public string GRSOrderNum { get; set; }
        public string PartnerSystemOrderNum { get; set; }
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string ItemOption { get; set; }
        public string Email { get; set; }
        public double? ProductCost { get; set; }
        public string CatalogCode { get; set; }
        public DateTime? DateProcessed { get; set; }
        public int? QuantityShipped { get; set; }
        public string TrackingNumber { get; set; }
        public string CourierName { get; set; }
        public string Memo { get; set; }
        public string Note { get; set; }
        public int? delayed { get; set; }
    }
}
