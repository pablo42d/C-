//using System;

namespace PhoneBookApp.Models
{
    // Abstrakcyjna klasa bazowa dla urządzeń
    public abstract class DeviceBase
    {
        public int DeviceID { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        public int? EmployeeID { get; set; }
        public string Model { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReplacementDate { get; set; }

        public string DeviceStatus { get; set; }
        public string Notes { get; set; }
    }
}
