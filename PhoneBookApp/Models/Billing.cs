//using System;

namespace PhoneBookApp.Models
{
    public class Billing
    {
        public int BillingID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime BillingMonth { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CallDate { get; set; }
        public int CallDuration { get; set; }
        public decimal CallCost { get; set; }
        public string Destination { get; set; }
    }
}

