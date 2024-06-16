using Newtonsoft.Json;

namespace EmployeeManagementSystemAssignment_Ruchika.Model
{
    public class EmployeeADModel
    {
  

        [JsonProperty(PropertyName = "employeeBDUId", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeBDUId { get; set; }

        [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateEmail { get; set; }

        [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateMobile { get; set; }

        [JsonProperty(PropertyName = "workInformation", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfo_Model WorkInformation { get; set; }

        [JsonProperty(PropertyName = "personalDetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetails_Model PersonalDetails { get; set; }

        [JsonProperty(PropertyName = "identityInformation", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityInfo_Model IdentityInformation { get; set; }



      
      
    }
}
