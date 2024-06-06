using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Linq;
using VisitorSecuritySystemAssignment_Ruchika.DTO;
using VisitorSecuritySystemAssignment_Ruchika.Interface;

namespace VisitorSecuritySystemAssignment_Ruchika.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorSecuritySystemController : Controller
    {
        public readonly IVSCSService _vSCSService;
        public VisitorSecuritySystemController(IVSCSService vSCSService)
        {
            _vSCSService = vSCSService;
        }

        //visitor

        [HttpPost]

        public async Task<VisitorModel> AddVisitor(VisitorModel visitorModel)
        {
            var response = await _vSCSService.AddVisitor(visitorModel);
            return response;
        }

        [HttpGet]

        public async Task<VisitorModel> GetVisitorByUId(string UId)
        {
            var response = await _vSCSService.GetVisitorByUId(UId);
            return response;
        }

        [HttpPost]

        public async Task<VisitorModel> UpdateVisitor(VisitorModel visitorModel)
        {
            var response = await _vSCSService.UpdateVisitor(visitorModel);
            return response;
        }

        [HttpPost]

        public async Task<string> DeleteVisitor(string UId)
        {
            var response = await _vSCSService.DeleteVisitor(UId);
            return response;
        }

        //Manager
        [HttpPost]
        public async Task<ManagerModel> AddManager(ManagerModel managerModel)
        {
            var response = await _vSCSService.AddManager(managerModel);
            return response;
        }

        [HttpGet]

        public async Task<ManagerModel> GetManagerByUId(string UId)
        {
            var response = await _vSCSService.GetManagerByUId(UId);
            return response;
        }

        [HttpPost]

        public async Task<ManagerModel> UpdateManager(ManagerModel managerModel)
        {
            var response = await _vSCSService.UpdateManager(managerModel);
            return response;
        }

        [HttpPost]

        public async Task<string> DeleteManager(string UId)
        {
            var response = await _vSCSService.DeleteManager(UId);
            return response;
        }

        //Security
        [HttpPost]

        public async Task<SecurityModel> AddSecurity(SecurityModel securityModel)
        {
            var response = await _vSCSService.AddSecurity(securityModel);
            return response;
        }

        [HttpGet]

        public async Task<SecurityModel> GetSecurityByUId(string UId)
        {
            var response = await _vSCSService.GetSecurityByUId(UId);
            return response;
        }

        [HttpPost]

        public async Task<SecurityModel> UpdateSecurity(SecurityModel securityModel)
        {
            var response = await _vSCSService.UpdateSecurity(securityModel);
            return response;
        }

        [HttpPost]

        public async Task<string> DeleteSecurity(string UId)
        {
            var response = await _vSCSService.DeleteSecurity(UId);
            return response;
        }

        //Office
        [HttpPost]

        public async Task<OfficeModel> AddOffice(OfficeModel officeModel)
        {
            var response = await _vSCSService.AddOffice(officeModel);
            return response;
        }

        [HttpGet]

        public async Task<OfficeModel> GetOfficeByUId(string UId)
        {
            var response = await _vSCSService.GetOfficeByUId(UId);
            return response;
        }

        [HttpPost]

        public async Task<OfficeModel> UpdateOffice(OfficeModel officeModel)
        {
            var response = await _vSCSService.UpdateOffice(officeModel);
            return response;
        }

        [HttpPost]

        public async Task<string> DeleteOffice(string UId)
        {
            var response = await _vSCSService.DeleteOffice(UId);
            return response;
        }

        //login

        [HttpPost]
        public async Task<string> Login(string Email, string UId)
        {
            var response = await _vSCSService.Login(Email, UId);
            return response;
        }

        //Visitorpass
        [HttpPost]

        public async Task<PassModel> AddPass(PassModel passModel)
        {
            var response = await _vSCSService.AddPass(passModel);
            return response;
        }

        [HttpGet]

        public async Task<PassModel> GetVisitorByStatus(string Status)
        {
            var response = await _vSCSService.GetVisitorByStatus(Status);
            return response;
        }


        [HttpPost]

        public async Task<PassModel> UpdatePassStatus(PassModel passModel)
        {
            var response = await _vSCSService.UpdatePassStatus(passModel);
            return response;
        }

        
       





    }
}
