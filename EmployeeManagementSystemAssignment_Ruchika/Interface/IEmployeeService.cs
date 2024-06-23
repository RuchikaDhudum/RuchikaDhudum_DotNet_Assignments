using EmployeeManagementSystemAssignment_Ruchika.Entities;
using EmployeeManagementSystemAssignment_Ruchika.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAssignment_Ruchika.Interface
{
    public interface IEmployeeService

    {
        //EmployeeBasicDetails
        Task<EmployeeBDModel> AddEmployeeBD(EmployeeBDModel employeeBDModel);
        Task<string> DeleteEmployeeBD(string uId);
        Task<List<EmployeeBDModel>> GetAllEmployeeBD();
        Task<EmployeeBDModel> GetEmployeeBDByUId(string uId);
        Task<EmployeeBDModel> UpdateEmployeeBD(EmployeeBDModel employeeBDModel);

        //Employee Additional details
        Task<EmployeeADModel> AddEmployeeAD(EmployeeADModel employeeADModel);
        Task<List<EmployeeADModel>> GetAllEmployeeAD();
        Task<EmployeeADModel> GetEmployeeADByUId(string EmployeeBDUId);
        Task<EmployeeADModel> UpdateEmployeeAD(EmployeeADModel employeeADModel);
        Task<string> DeleteEmployeAD(string uId);
        //filter
        Task<List<EmployeeBDModel>> GetAllEmployeeByRole(string role);
        Task<EmployeeFilterCriteria> GetAllEmployeeByPagination(EmployeeFilterCriteria employeeFilterCriteria);
        Task<VisitorModel>AddVisitorByMakePostRequest(VisitorModel visitorModel);
        Task<List<VisitorModel>> GetVisitorByMakeGetRequest();
        Task<EmployeeADFilterCriteria> GetAllEmployeeADByPagination(EmployeeADFilterCriteria employeeADFilterCriteria);
    }
}
