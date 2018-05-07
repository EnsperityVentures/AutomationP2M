using System;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_Entities
{
    public class GRSDailyOrders
    {
        public string GRSOrder { get; set; }
        public string PartnerSystemOrder { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string ItemOption { get; set; }
        public int? Quantity { get; set; }
        public string Email { get; set; }
        public double ProductCost { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string Status { get; set; }
        public int? QuantityShipped { get; set; }
        public string TrackingNumber { get; set; }
        public string CourierName { get; set; }
        public string Memo { get; set; }
        //public int? delayed { get; set; }
    }
}
