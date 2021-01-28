namespace IoTDevicesApi.Models
{
    public class IoTDevice
    {
        public string id { get; set; }
        public string devEui { get; set; }
        public string appKey { get; set; }
        public string type { get; set; }
        public string comment { get; set; }
        public string docVer { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string propertyNo { get; set; }
        public string buildingName { get; set; }
        public string buildingNo { get; set; }
        public string gNr { get; set; }
        public string bNr { get; set; }
        public string placement { get; set; }
        public string equipment { get; set; }
        public string roomNo { get; set; }
        public string zone { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
    }
}