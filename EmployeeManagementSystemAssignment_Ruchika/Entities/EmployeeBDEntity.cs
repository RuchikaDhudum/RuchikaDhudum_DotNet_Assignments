using EmployeeManagementSystemAssignment_Ruchika.Common;
using EmployeeManagementSystemAssignment_Ruchika.Model;
using Newtonsoft.Json;

namespace EmployeeManagementSystemAssignment_Ruchika.Entities
{
    public class EmployeeBDEntity : BaseEntity
    {
        [JsonProperty(PropertyName = "Salutory", NullValueHandling = NullValueHandling.Ignore)]
        public string Salutory { get; set; }

        [JsonProperty(PropertyName = "firstName", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "middleName", NullValueHandling = NullValueHandling.Ignore)]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "lastName", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "nickName", NullValueHandling = NullValueHandling.Ignore)]
        public string NickName { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "mobile", NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile { get; set; }

        [JsonProperty(PropertyName = "employeeId", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeID { get; set; }

        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore)]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "reportingManagerUId", NullValueHandling = NullValueHandling.Ignore)]
        public string ReportingManagerUId { get; set; }

        [JsonProperty(PropertyName = "reportingManagerName", NullValueHandling = NullValueHandling.Ignore)]
        public string ReportingManagerName { get; set; }

        [JsonProperty(PropertyName = "address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
    }

    public class EmployeeFilterCriteria
    {

        public EmployeeFilterCriteria()
        {
            Filters = new List<FilterCriteria>();
            employees = new List<EmployeeBDModel>();
        }
        public int page { get; set; }//page no

        public int pageSize { get; set; }//no of records on 1 page
        public int totalCount { get; set; }//total records present in database

        public List<FilterCriteria> Filters { get; set; } //pass filter

        public List<EmployeeBDModel> employees { get; set; }
    }

    public class FilterCriteria
    {
        public string FieldName { get; set; } //role

        public string FieldValue { get; set; }
    }
}
