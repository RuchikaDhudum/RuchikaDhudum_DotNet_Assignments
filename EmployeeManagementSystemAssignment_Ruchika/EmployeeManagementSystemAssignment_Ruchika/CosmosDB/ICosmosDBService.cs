using EmployeeManagementSystemAssignment_Ruchika.Entities;

namespace EmployeeManagementSystemAssignment_Ruchika.CosmosDB
{
    public interface ICosmosDBService
    {
       //Employee Basic details
        Task<EmployeeBDEntity> AddEmployeeBD(EmployeeBDEntity employee);
        Task<List<EmployeeBDEntity>> GetAllEmployeeBD();
        Task<EmployeeBDEntity> GetEmployeeBDByUId(string uId);
        public Task ReplaceAsync(dynamic entity);

        //Employee additional details
        Task<EmployeeADEntity> AddEmployeeAD(EmployeeADEntity employee);
        Task<List<EmployeeADEntity>> GetAllEmployeeAD();
        Task<EmployeeADEntity> GetEmployeeADByUId(string EmployeeBDUId);
    }
}
