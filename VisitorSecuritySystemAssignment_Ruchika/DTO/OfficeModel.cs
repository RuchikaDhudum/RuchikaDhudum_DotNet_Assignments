using Newtonsoft.Json;

namespace VisitorSecuritySystemAssignment_Ruchika.DTO
{
    public class OfficeModel
    {
        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }

        [JsonProperty(PropertyName = "officeName", NullValueHandling = NullValueHandling.Ignore)]
        public string OfficeName { get; set; }

        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }
    }
}
