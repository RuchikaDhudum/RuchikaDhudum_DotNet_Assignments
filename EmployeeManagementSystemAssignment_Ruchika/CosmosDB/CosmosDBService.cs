using EmployeeManagementSystemAssignment_Ruchika.Common;
using EmployeeManagementSystemAssignment_Ruchika.Entities;
using Microsoft.Azure.Cosmos;

namespace EmployeeManagementSystemAssignment_Ruchika.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDBService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.DataBaseName, Credentials.ContainerName);
        }

        public async Task<EmployeeBDEntity> AddEmployeeBD(EmployeeBDEntity employee)
        {
            var response = await _container.CreateItemAsync(employee);
            return response;
        }

        public async Task<List<EmployeeBDEntity>> GetAllEmployeeBD()
        {
            var response = _container.GetItemLinqQueryable<EmployeeBDEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "employeeBD").ToList();
            return response;
        }

        public async Task<EmployeeBDEntity> GetEmployeeBDByUId(string uId)
        {
            var response = _container.GetItemLinqQueryable<EmployeeBDEntity>(true).Where(q => q.UId == uId && q.Active == true && q.Archived == false && q.DocumentType == "employeeBD").FirstOrDefault();
            return response;
        }

        public async Task ReplaceAsync(dynamic entity)
        {
            var response = await _container.ReplaceItemAsync(entity, entity.Id);
        }

        //Employee aditional deatils
        public async Task<EmployeeADEntity> AddEmployeeAD(EmployeeADEntity employee)
        {
            var response = await _container.CreateItemAsync(employee);
            return response;
        }

        public async Task<List<EmployeeADEntity>> GetAllEmployeeAD()
        {
            var response = _container.GetItemLinqQueryable<EmployeeADEntity>(true).Where(q => q.Active == true && q.Archived == false && q.DocumentType == "employeeAD").ToList();
            return response;
        }

        public async Task<EmployeeADEntity> GetEmployeeADByUId(string EmployeeBDUId)
        {
            var response = _container.GetItemLinqQueryable<EmployeeADEntity>(true).Where(q => q.EmployeeBDUId == EmployeeBDUId && q.Active == true && q.Archived == false && q.DocumentType == "employeeAD").FirstOrDefault();
            return response;
        }
    }
}
