using System;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_Entities
{
    public class Clients_Invoices
    {
        public string OrderNo { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CatalogName { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public string RedemptionPoints { get; set; }
        public double LocalCost { get; set; }
        public double TotalLocalCost { get; set; }
        public double USDCost { get; set; }
        public double TotalUSDCost { get; set; }
        public string ReasonofReturen { get; set; }
        //public Currency Currency_ID { get; set; }
        public string Country { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
    }
}
