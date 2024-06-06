using VisitorSecuritySystemAssignment_Ruchika.DTO;

namespace VisitorSecuritySystemAssignment_Ruchika.Interface
{
    public interface IVSCSService
    {
        //visitor
        Task<VisitorModel> AddVisitor(VisitorModel visitorModel);

        Task<VisitorModel> GetVisitorByUId(string UId);

        Task<VisitorModel> UpdateVisitor(VisitorModel visitorModel);

        Task<String> DeleteVisitor(string UId);

        //manager
        Task<ManagerModel> AddManager(ManagerModel managerModel);

        Task<ManagerModel> GetManagerByUId(string UId);

        Task<ManagerModel> UpdateManager(ManagerModel managerModel);

        Task<String> DeleteManager(string UId);

        //Security

        Task<SecurityModel> AddSecurity(SecurityModel securityModel);

        Task<SecurityModel> GetSecurityByUId(string UId);

        Task<SecurityModel> UpdateSecurity(SecurityModel securityModel);

        Task<String> DeleteSecurity(string UId);

        //Office

        Task<OfficeModel> AddOffice(OfficeModel officeModel);

        Task<OfficeModel> GetOfficeByUId(string UId);

        Task<OfficeModel> UpdateOffice(OfficeModel officeModel);

        Task<String> DeleteOffice(string UId);

        //Login
        Task<string> Login(string Email, string UId);

        //pass
        Task<PassModel> AddPass(PassModel passModel);

        Task<PassModel> UpdatePassStatus(PassModel passModel);

        Task<PassModel> GetVisitorByStatus(string Status);

        








    }
}
