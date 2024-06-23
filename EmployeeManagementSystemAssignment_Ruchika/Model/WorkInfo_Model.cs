﻿using EmployeeManagementSystemAssignment_Ruchika.Entities;
using Newtonsoft.Json;

namespace EmployeeManagementSystemAssignment_Ruchika.Model
{
    public class WorkInfo_Model
    {
        [JsonProperty(PropertyName = "designationName", NullValueHandling = NullValueHandling.Ignore)]
        public string DesignationName { get; set; }

        [JsonProperty(PropertyName = "departmentName", NullValueHandling = NullValueHandling.Ignore)]
        public string DepartmentName { get; set; }

        [JsonProperty(PropertyName = "locationName", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationName { get; set; }

        [JsonProperty(PropertyName = "employeeStatus", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeStatus { get; set; } // Terminated, Active, Resigned etc

        [JsonProperty(PropertyName = "sourceOfhire", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceOfHire { get; set; }

        [JsonProperty(PropertyName = "dateOfJoining", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateOfJoining { get; set; }

       }
    }
