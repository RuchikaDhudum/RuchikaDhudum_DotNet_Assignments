using Newtonsoft.Json;

namespace VisitorSecuritySystemAssignment_Ruchika.DTO
{
    public class LoginModel
    {
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "uId", NullValueHandling = NullValueHandling.Ignore)]
        public string UId { get; set; }
    }
}
