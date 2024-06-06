using Microsoft.Azure.Cosmos;
using VisitorSecuritySystemAssignment_Ruchika.Common;
using VisitorSecuritySystemAssignment_Ruchika.Entities;

namespace VisitorSecuritySystemAssignment_Ruchika.CosmosDB
{
    public class CosmosDBService : ICosmosDBService
    {
        public CosmosClient _cosmosClient;
        private readonly Container _container;

        public CosmosDBService()
        {
            _cosmosClient = new CosmosClient(Credentials.CosmosEndPoint, Credentials.PrimaryKey);
            _container = _cosmosClient.GetContainer(Credentials.databaseName, Credentials.containerName);
        }

        //visitor
        public async Task<VisitorEntity> AddVisitor(VisitorEntity visitor)
        {
            var response = await _container.CreateItemAsync(visitor);
            return response;
        }

        public async Task<VisitorEntity> GetVisitorByUId(string UId)
        {
            var visitor = _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();
            return visitor;
        }

       

        public  async Task ReplaceAsync(VisitorEntity visitor)
        {
            var response = await _container.ReplaceItemAsync(visitor, visitor.Id);

        }

        //manager
        public async Task<ManagerEntity> AddManager(ManagerEntity manager)
        {
            var response = await _container.CreateItemAsync(manager);
            return response;
        }

        public async Task<ManagerEntity> GetManagerByUId(string UId)
        {
            var manager = _container.GetItemLinqQueryable<ManagerEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();
            return manager;
        }



        public async Task ReplaceAsync(ManagerEntity manager)
        {
            var response = await _container.ReplaceItemAsync(manager, manager.Id);

        }

        //Security
        public async Task<SecurityEntity> AddSecurity(SecurityEntity security)
        {
            var response = await _container.CreateItemAsync(security);
            return response;
        }

        public async Task<SecurityEntity> GetSecurityByUId(string UId)
        {
            var security= _container.GetItemLinqQueryable<SecurityEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();
            return security;
        }



        public async Task ReplaceAsync(SecurityEntity security)
        {
            var response = await _container.ReplaceItemAsync(security, security.Id);

        }

        //office

        public async Task<OfficeEntity> AddOffice(OfficeEntity office)
        {
            var response = await _container.CreateItemAsync(office);
            return response;
        }

        public async Task<OfficeEntity> GetOfficeByUId(string UId)
        {
            var office = _container.GetItemLinqQueryable<OfficeEntity>(true).Where(q => q.UId == UId && q.Active == true && q.Archived == false).FirstOrDefault();
            return office;
        }



        public async Task ReplaceAsync(OfficeEntity office)
        {
            var response = await _container.ReplaceItemAsync(office, office.Id);

        }

        public async Task<VisitorEntity> Login(string Email, string UId)
        {
            var login= _container.GetItemLinqQueryable<VisitorEntity>(true).Where(q => q.Email == Email && q.UId == UId).FirstOrDefault();
            return login;
        }

        //pass

        public async Task<PassEntity> AddPass(PassEntity pass)
        {
            var response = await _container.CreateItemAsync(pass);
            return response;
        }

        public async Task<PassEntity> GetVisitorByStatus(string Status)
        {
            var pass = _container.GetItemLinqQueryable<PassEntity>(true).Where(q => q.Status == Status && q.Active == true && q.Archived == false).FirstOrDefault();
            return pass;
        }



        public async Task ReplaceAsync(PassEntity pass)
        {
            var response = await _container.ReplaceItemAsync(pass, pass.Id);

        }

    }
}
