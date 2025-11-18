namespace PhoneBookApp.Models
{
    public class MobileDevice : DeviceBase
    {
        public string IMEI { get; set; }
        public bool HasMDM { get; set; }
    }
}

