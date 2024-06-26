using AutoMapper;
using EmployeeManagementSystemAssignment_Ruchika.Entities;
using EmployeeManagementSystemAssignment_Ruchika.Model;

namespace EmployeeManagementSystemAssignment_Ruchika.Common
{
    public class AutomapperProfile:Profile
        
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeADEntity, EmployeeADModel>().ReverseMap();
            CreateMap<WorkInfo_, WorkInfo_Model>().ReverseMap();
            CreateMap<IdentityInfo_, IdentityInfo_Model>().ReverseMap();
            CreateMap<PersonalDetails_, PersonalDetails_Model>().ReverseMap();
           
        }
    }
}
