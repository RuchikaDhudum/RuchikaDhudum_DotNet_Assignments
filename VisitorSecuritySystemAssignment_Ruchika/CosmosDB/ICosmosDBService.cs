using VisitorSecuritySystemAssignment_Ruchika.Entities;

namespace VisitorSecuritySystemAssignment_Ruchika.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<VisitorEntity> AddVisitor(VisitorEntity visitor);

        Task<VisitorEntity> GetVisitorByUId(string uId);
        Task ReplaceAsync(VisitorEntity existingVisitor);

        //manager
        Task<ManagerEntity> AddManager(ManagerEntity manager);

        Task<ManagerEntity> GetManagerByUId(string uId);
        Task ReplaceAsync(ManagerEntity existingManager);

        //security
        Task<SecurityEntity> AddSecurity(SecurityEntity security);

        Task<SecurityEntity> GetSecurityByUId(string uId);
        Task ReplaceAsync(SecurityEntity existingSecurity);

        //office

        Task<OfficeEntity> AddOffice(OfficeEntity office);

        Task<OfficeEntity> GetOfficeByUId(string uId);
        Task ReplaceAsync(OfficeEntity existingOffice);

        Task<VisitorEntity> Login(string email, string uId);


        //pass
        Task<PassEntity> AddPass(PassEntity pass);

        Task<PassEntity> GetVisitorByStatus(string Status);
        Task ReplaceAsync(PassEntity existingPass);

    }
}
 