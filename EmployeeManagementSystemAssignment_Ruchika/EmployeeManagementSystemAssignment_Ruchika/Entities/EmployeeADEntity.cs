using EmployeeManagementSystemAssignment_Ruchika.Common;
using EmployeeManagementSystemAssignment_Ruchika.Model;
using Newtonsoft.Json;

namespace EmployeeManagementSystemAssignment_Ruchika.Entities
{
    public class EmployeeADEntity : BaseEntity
    {
        

            [JsonProperty(PropertyName = "employeeBDUId", NullValueHandling = NullValueHandling.Ignore)]
            public string EmployeeBDUId { get; set; }

            [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
            public string AlternateEmail { get; set; }

            [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
            public string AlternateMobile { get; set; }

            [JsonProperty(PropertyName = "workInformation", NullValueHandling = NullValueHandling.Ignore)]
            public WorkInfo_ WorkInformation { get; set; }

            [JsonProperty(PropertyName = "personalDetails", NullValueHandling = NullValueHandling.Ignore)]
            public PersonalDetails_ PersonalDetails { get; set; }

            [JsonProperty(PropertyName = "identityInformation", NullValueHandling = NullValueHandling.Ignore)]
            public IdentityInfo_ IdentityInformation { get; set; }

            [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
             public string Status { get; set; }


    }


    public class EmployeeADFilterCriteria
    {

        public EmployeeADFilterCriteria()
        {
            Filters = new List<FilterCriteriaAD>();
            Employees = new List<EmployeeADModel>();
        }
        public int page { get; set; }//page no

        public int pageSize { get; set; }//no of records on 1 page
        public int totalCount { get; set; }//total records present in database

        public List<FilterCriteriaAD> Filters { get; set; } //pass filter

        public List<EmployeeADModel> Employees { get; set; }
    }

    public class FilterCriteriaAD
    {
        public string FieldName { get; set; } //employeeStatus

        public string FieldValue { get; set; }
    }
}
