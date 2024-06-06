using VisitorSecuritySystemAssignment_Ruchika.CosmosDB;
using VisitorSecuritySystemAssignment_Ruchika.DTO;
using VisitorSecuritySystemAssignment_Ruchika.Entities;
using VisitorSecuritySystemAssignment_Ruchika.Interface;

namespace VisitorSecuritySystemAssignment_Ruchika.Services
{
    public class VSCSService : IVSCSService
    {
        public readonly ICosmosDBService _cosmosDBService;
        public VSCSService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }

        //visitor

        public async Task<VisitorModel> AddVisitor(VisitorModel visitorModel)
        {
            VisitorEntity visitor = new VisitorEntity();
            
            visitor.Name = visitorModel.Name;
            visitor.Email = visitorModel.Email;
            visitor.PhoneNumber = visitorModel.PhoneNumber;
             visitor.Id = Guid.NewGuid().ToString();
             visitor.UId = visitor.Id;
             visitor.CreatedBy = "Ruchika";
             visitor.CreatedOn = DateTime.Now;
             visitor.UpdatedBy = "";
             visitor.UpdatedOn = DateTime.Now;
             visitor.DocumentType = "visitor";
             visitor.Version = 1;
             visitor.Active = true;
             visitor.Archived = false;



            var response = await _cosmosDBService.AddVisitor(visitor);

            var responseModel = new VisitorModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }

        

        public async Task<VisitorModel> GetVisitorByUId(string UId)
        {
            var response = await _cosmosDBService.GetVisitorByUId(UId);

            var responseModel = new VisitorModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }

        public async Task<VisitorModel> UpdateVisitor(VisitorModel visitorModel)
        {
            var existingVisitor = await _cosmosDBService.GetVisitorByUId(visitorModel.UId);
            existingVisitor.Archived = true;
            existingVisitor.Active = false;


            await _cosmosDBService.ReplaceAsync(existingVisitor);
            
            existingVisitor.Name = visitorModel.Name;
            existingVisitor.Email = visitorModel.Email;
            existingVisitor.PhoneNumber = visitorModel.PhoneNumber;
            existingVisitor.Id = Guid.NewGuid().ToString();
            existingVisitor.UId = visitorModel.UId;
            existingVisitor.CreatedBy = "Ruchika";
            existingVisitor.CreatedOn = DateTime.Now;
            existingVisitor.UpdatedBy = "";
            existingVisitor.UpdatedOn = DateTime.Now;
            existingVisitor.DocumentType = "visitor";
            existingVisitor.Version = existingVisitor.Version + 1;
            existingVisitor.Active = true;
            existingVisitor.Archived = false;

            var response = await _cosmosDBService.AddVisitor(existingVisitor);

            var responseModel = new VisitorModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }
        public async  Task<string> DeleteVisitor(string UId)
        {
            var visitor = await _cosmosDBService.GetVisitorByUId(UId);
            visitor.Active = false;
            visitor.Archived = true;
            
            await _cosmosDBService.ReplaceAsync(visitor);
            visitor.CreatedBy = "Ruchika";
            visitor.CreatedOn = DateTime.Now;
            visitor.UpdatedBy = "";
            visitor.UpdatedOn = DateTime.Now;
            visitor.DocumentType = "visitor";
            visitor.Active = false;



            await _cosmosDBService.AddVisitor(visitor);
            return "Record Deleted Successfully";

        }

        //manager
        public async Task<ManagerModel> AddManager(ManagerModel managerModel)
        {
            ManagerEntity manager = new ManagerEntity();

            manager.Name = managerModel.Name;
            manager.Email = managerModel.Email;
            manager.PhoneNumber = managerModel.PhoneNumber;
            manager.Id = Guid.NewGuid().ToString();
            manager.UId = manager.Id;
            manager.CreatedBy = "Ruchika";
            manager.CreatedOn = DateTime.Now;
            manager.UpdatedBy = "";
            manager.UpdatedOn = DateTime.Now;
            manager.DocumentType = "visitor";
            manager.Version = 1;
            manager.Active = true;
            manager.Archived = false;



            var response = await _cosmosDBService.AddManager(manager);

            var responseModel = new ManagerModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }



        public async Task<ManagerModel> GetManagerByUId(string UId)
        {
            var response = await _cosmosDBService.GetManagerByUId(UId);

            var responseModel = new ManagerModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }

        public async Task<ManagerModel> UpdateManager(ManagerModel managerModel)
        {
            var existingManager = await _cosmosDBService.GetManagerByUId(managerModel.UId);
            existingManager.Archived = true;
            existingManager.Active = false;


            await _cosmosDBService.ReplaceAsync(existingManager);

            existingManager.Name = managerModel.Name;
            existingManager.Email = managerModel.Email;
            existingManager.PhoneNumber = managerModel.PhoneNumber;
            existingManager.Id = Guid.NewGuid().ToString();
            existingManager.UId = managerModel.UId;
            existingManager.CreatedBy = "Ruchika";
            existingManager.CreatedOn = DateTime.Now;
            existingManager.UpdatedBy = "";
            existingManager.UpdatedOn = DateTime.Now;
            existingManager.DocumentType = "Manager";
            existingManager.Version = existingManager.Version + 1;
            existingManager.Active = true;
            existingManager.Archived = false;

            var response = await _cosmosDBService.AddManager(existingManager); ;

            var responseModel = new ManagerModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }
        public async Task<string> DeleteManager(string UId)
        {
            var manager = await _cosmosDBService.GetManagerByUId(UId);
            manager.Active = false;
            manager.Archived = true;

            await _cosmosDBService.ReplaceAsync(manager);
            manager.CreatedBy = "Ruchika";
            manager.CreatedOn = DateTime.Now;
            manager.UpdatedBy = "";
            manager.UpdatedOn = DateTime.Now;
            manager.DocumentType = "Manager";
            manager.Active = false;



            await _cosmosDBService.AddManager(manager);
            return "Record Deleted Successfully";

        }

        //Security

        public async Task<SecurityModel> AddSecurity(SecurityModel securityModel)
        {
            SecurityEntity security = new SecurityEntity();

            security.Name = securityModel.Name;
            security.Email = securityModel.Email;
            security.PhoneNumber = securityModel.PhoneNumber;
            security.Id = Guid.NewGuid().ToString();
            security.UId = security.Id;
            security.CreatedBy = "Ruchika";
            security.CreatedOn = DateTime.Now;
            security.UpdatedBy = "";
            security.UpdatedOn = DateTime.Now;
            security.DocumentType = "security";
            security.Version = 1;
            security.Active = true;
            security.Archived = false;



            var response = await _cosmosDBService.AddSecurity(security);

            var responseModel = new SecurityModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }



        public async Task<SecurityModel> GetSecurityByUId(string UId)
        {
            var response = await _cosmosDBService.GetSecurityByUId(UId);

            var responseModel = new SecurityModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }

        public async Task<SecurityModel> UpdateSecurity(SecurityModel securityModel)
        {
            var existingSecurity = await _cosmosDBService.GetSecurityByUId(securityModel.UId);
            existingSecurity.Archived = true;
            existingSecurity.Active = false;


            await _cosmosDBService.ReplaceAsync(existingSecurity);

            existingSecurity.Name = securityModel.Name;
            existingSecurity.Email = securityModel.Email;
            existingSecurity.PhoneNumber = securityModel.PhoneNumber;
            existingSecurity.Id = Guid.NewGuid().ToString();
            existingSecurity.UId = securityModel.UId;
            existingSecurity.CreatedBy = "Ruchika";
            existingSecurity.CreatedOn = DateTime.Now;
            existingSecurity.UpdatedBy = "";
            existingSecurity.UpdatedOn = DateTime.Now;
            existingSecurity.DocumentType = "security";
            existingSecurity.Version = existingSecurity.Version + 1;
            existingSecurity.Active = true;
            existingSecurity.Archived = false;

            var response = await _cosmosDBService.AddSecurity(existingSecurity);

            var responseModel = new SecurityModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Email = response.Email;
            responseModel.PhoneNumber = response.PhoneNumber;

            return responseModel;

        }
        public async Task<string> DeleteSecurity(string UId)
        {
            var security = await _cosmosDBService.GetSecurityByUId(UId);
            security.Active = false;
            security.Archived = true;

            await _cosmosDBService.ReplaceAsync(security);
            security.CreatedBy = "Ruchika";
            security.CreatedOn = DateTime.Now;
            security.UpdatedBy = "";
            security.UpdatedOn = DateTime.Now;
            security.DocumentType = "security";
            security.Active = false;



            await _cosmosDBService.AddSecurity(security);
            return "Record Deleted Successfully";

        }

        //Office
        public async Task<OfficeModel> AddOffice(OfficeModel officeModel)
        {
            OfficeEntity office = new OfficeEntity();

            office.OfficeName = officeModel.OfficeName;
            office.Location = officeModel.Location;
            office.Id = Guid.NewGuid().ToString();
            office.UId = office.Id;
            office.CreatedBy = "Ruchika";
            office.CreatedOn = DateTime.Now;
            office.UpdatedBy = "";
            office.UpdatedOn = DateTime.Now;
            office.DocumentType = "office";
            office.Version = 1;
            office.Active = true;
            office.Archived = false;



            var response = await _cosmosDBService.AddOffice(office);

            var responseModel = new OfficeModel();
            responseModel.UId = response.UId;
            responseModel.OfficeName = response.OfficeName;
            responseModel.Location = response.Location;

            return responseModel;

        }



        public async Task<OfficeModel> GetOfficeByUId(string UId)
        {
            var response = await _cosmosDBService.GetOfficeByUId(UId);

            var responseModel = new OfficeModel();
            responseModel.UId = response.UId;
            responseModel.OfficeName = response.OfficeName;
            responseModel.Location = response.Location;

            return responseModel;

        }

        public async Task<OfficeModel> UpdateOffice(OfficeModel officeModel)
        {
            var existingOffice = await _cosmosDBService.GetOfficeByUId(officeModel.UId);
            existingOffice.Archived = true;
            existingOffice.Active = false;


            await _cosmosDBService.ReplaceAsync(existingOffice);

            existingOffice.OfficeName = officeModel.OfficeName;
            existingOffice.Location = officeModel.Location;
            existingOffice.Id = Guid.NewGuid().ToString();
            existingOffice.UId = officeModel.UId;
            existingOffice.CreatedBy = "Ruchika";
            existingOffice.CreatedOn = DateTime.Now;
            existingOffice.UpdatedBy = "";
            existingOffice.UpdatedOn = DateTime.Now;
            existingOffice.DocumentType = "office";
            existingOffice.Version = existingOffice.Version + 1;
            existingOffice.Active = true;
            existingOffice.Archived = false;

            var response = await _cosmosDBService.AddOffice(existingOffice);

            var responseModel = new OfficeModel();
            responseModel.UId = response.UId;
            responseModel.OfficeName = response.OfficeName;
            responseModel.Location = response.Location ;
            
            return responseModel;

        }
        public async Task<string> DeleteOffice(string UId)
        {
            var office = await _cosmosDBService.GetOfficeByUId(UId);
            office.Active = false;
            office.Archived = true;

            await _cosmosDBService.ReplaceAsync(office);
            office.CreatedBy = "Ruchika";
            office.CreatedOn = DateTime.Now;
            office.UpdatedBy = "";
            office.UpdatedOn = DateTime.Now;
            office.DocumentType = "office";
            office.Active = false;



            await _cosmosDBService.AddOffice(office);
            return "Record Deleted Successfully";

        }

        public async Task<string> Login(string Email , string UId)
        {
            var response = await _cosmosDBService.Login(Email, UId);

            if(response == null )
            {
                return "you can start to register";
            }
            return "already exist";


            
        }

        //pass

        public async Task<PassModel> AddPass(PassModel passModel)
        {
            PassEntity pass = new PassEntity();

            pass.Name = passModel.Name;
            pass.Role = passModel.Role;
            pass.Status = passModel.Status;
            pass.Id = Guid.NewGuid().ToString();
            pass.UId = pass.Id;
            pass.CreatedBy = "Ruchika";
            pass.CreatedOn = DateTime.Now;
            pass.UpdatedBy = "";
            pass.UpdatedOn = DateTime.Now;
            pass.DocumentType = "pass";
            pass.Version = 1;
            pass.Active = true;
            pass.Archived = false;



            var response = await _cosmosDBService.AddPass(pass);

            var responseModel = new PassModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Role = response.Role;
            responseModel.Status = response.Status;

            return responseModel;

        }

        public async Task<PassModel> GetVisitorByStatus(string Status)
        {
            var response = await _cosmosDBService.GetVisitorByStatus(Status);

            var responseModel = new PassModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Role = response.Role;
            responseModel.Status = response.Status;

            return responseModel;

        }

        public async Task<PassModel> UpdatePassStatus(PassModel passModel)
        {
            var existingPass= await _cosmosDBService.GetVisitorByStatus(passModel.Status);
            existingPass.Archived = true;
            existingPass.Active = false;


            await _cosmosDBService.ReplaceAsync(existingPass);

            existingPass.Name = passModel.Name;
            existingPass.Role = passModel.Role;
            existingPass.Status = passModel.Status;
            existingPass.Id = Guid.NewGuid().ToString();
            existingPass.UId = passModel.UId;
            existingPass.CreatedBy = "Ruchika";
            existingPass.CreatedOn = DateTime.Now;
            existingPass.UpdatedBy = "";
            existingPass.UpdatedOn = DateTime.Now;
            existingPass.DocumentType = "pass";
            existingPass.Version = existingPass.Version + 1;
            existingPass.Active = true;
            existingPass.Archived = false;

            var response = await _cosmosDBService.AddPass(existingPass);

            var responseModel = new PassModel();
            responseModel.UId = response.UId;
            responseModel.Name = response.Name;
            responseModel.Role = response.Role;
            responseModel.Status = response.Status;

            return responseModel;

        }


       

        
        


    }
}
