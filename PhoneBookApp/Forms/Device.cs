/* AdminPanel.cs
    Panel administracyjny do zarządzania pracownikami, działami i urządzeniami.
    Umożliwia dodawanie, edytowanie i usuwanie rekordów oraz import danych rozliczeniowych.
*/
using PhoneBookApp.Models;
using System;

namespace PhoneBookApp.Forms
{
    public class Device : DeviceBase // Dziedziczenie z DeviceBase
    {
        // Pola specyficzne, których nie było w DeviceBase.cs:
        public string DeviceType { get; set; }
        public string IMEI { get; set; }
        public string MACAddress { get; set; }
        public bool HasMDM { get; set; } // Zmieniono z nullable na non-nullable

        // Pola z DeviceBase (IssueDate i ReplacementDate) są już DateTime?
    }
    //internal class Device
    //{
    //}
}