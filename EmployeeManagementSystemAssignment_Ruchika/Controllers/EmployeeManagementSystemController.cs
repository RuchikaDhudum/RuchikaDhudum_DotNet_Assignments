using EmployeeManagementSystemAssignment_Ruchika.Entities;
using EmployeeManagementSystemAssignment_Ruchika.Interface;
using EmployeeManagementSystemAssignment_Ruchika.Model;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace EmployeeManagementSystemAssignment_Ruchika.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    //EmployeeBasicDeytails
    public class EmployeeManagementSystemController : Controller
    {
        public readonly IEmployeeService _employeeService;

        public EmployeeManagementSystemController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]

        public async Task<EmployeeBDModel> AddEmployeeBD(EmployeeBDModel employeeBDModel)
        {
            var response = await _employeeService.AddEmployeeBD(employeeBDModel);
            return response;
        }

        [HttpGet]

        public async Task<List<EmployeeBDModel>> GetAllEmployeeBD()
        {
            var response = await _employeeService.GetAllEmployeeBD();
            return response;
        }

        [HttpGet]

        public async Task<EmployeeBDModel> GetEmployeeBDByUId(string UId)
        {
            var response = await _employeeService.GetEmployeeBDByUId(UId);
            return response;
        }

        [HttpPost]

        public async Task<EmployeeBDModel> UpdateEmployeeBD(EmployeeBDModel employeeBDModel)
        {
            var response = await _employeeService.UpdateEmployeeBD(employeeBDModel);
            return response;
        }

        [HttpPost]

        public async Task<string> DeleteEmployeeBD(string UId)
        {
            var response = await _employeeService.DeleteEmployeeBD(UId);
            return response;
        }

        //EmployeeAditionalDetails

        [HttpPost]

        public async Task<EmployeeADModel> AddEmployeeAD(EmployeeADModel employeeADModel)
        {
            var response = await _employeeService.AddEmployeeAD(employeeADModel);
            return response;
        }

        [HttpGet]

        public async Task<List<EmployeeADModel>> GetAllEmployeeAD()
        {
            var response = await _employeeService.GetAllEmployeeAD();
            return response;
        }

        [HttpGet]

        public async Task<EmployeeADModel> GetEmployeeADByUId(string EmployeeBDUId)
        {
            var response = await _employeeService.GetEmployeeADByUId(EmployeeBDUId);
            return response;
        }

        [HttpPost]

        public async Task<EmployeeADModel> UpdateEmployeeAD(EmployeeADModel employeeADModel)
        {
            var response = await _employeeService.UpdateEmployeeAD(employeeADModel);
            return response;
        }

        [HttpPost]

        public async Task<string> DeleteEmployeeAD(string UId)
        {
            var response = await _employeeService.DeleteEmployeAD(UId);
            return response;
        }

        //***import and export for employeeBasic details**

        //IMPORT

        private string GetStringFromCell (ExcelWorksheet worksheet , int row, int column)
        {
            var cellValue = worksheet.Cells[row, column].Value;
            return cellValue?.ToString()?.Trim();
        }

        [HttpPost]

        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty or null");

            var employees = new List<EmployeeBDModel>();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using(var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for(int row = 2; row <= rowCount; row++)
                    {

                        var employee = new EmployeeBDModel
                        {
                            Salutory = GetStringFromCell(worksheet, row, 1),
                            FirstName = GetStringFromCell(worksheet, row, 2),
                            MiddleName = GetStringFromCell(worksheet,row, 3),
                            LastName = GetStringFromCell(worksheet,row, 4),
                            NickName = GetStringFromCell(worksheet, row, 5),
                            Email = GetStringFromCell(worksheet,row, 6),
                            Mobile = GetStringFromCell(worksheet, row, 7),
                            EmployeeID = GetStringFromCell(worksheet, row, 8),
                            Role = GetStringFromCell(worksheet, row, 9),
                            ReportingManagerUId = GetStringFromCell(worksheet, row, 10),
                            ReportingManagerName = GetStringFromCell(worksheet, row, 11),
                            Address = GetStringFromCell(worksheet, row, 12)

                        };
                        await AddEmployeeBD(employee);

                        employees.Add(employee);
                    }
                }
            }
            return Ok((employees));


        }

        //EXPORT

        [HttpGet]

        public async Task<IActionResult> ExportEmployeeBD()
        {
            var employees = await _employeeService.GetAllEmployeeBD();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using( var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("employees");

                worksheet.Cells[1, 1].Value = "UId";
                worksheet.Cells[1, 2].Value = "Salutory";
                worksheet.Cells[1, 3].Value = "FirstName";
                worksheet.Cells[1, 4].Value = "Middlename";
                worksheet.Cells[1, 5].Value = "Lastname";
                worksheet.Cells[1, 6].Value = "NickName";
                worksheet.Cells[1, 7].Value = "Email";
                worksheet.Cells[1, 8].Value = "Mobile";
                worksheet.Cells[1, 9].Value = "EmployeeID";
                worksheet.Cells[1, 10].Value = "Role";
                worksheet.Cells[1, 11].Value = "ReportingManagerUId";
                worksheet.Cells[1, 12].Value = "ReportingManagerName";
                worksheet.Cells[1, 13].Value = "Address";

                using (var range = worksheet.Cells[1, 1, 1, 13])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);

                }

                for(int i=0; i< employees.Count; i++)
                {
                    var employee = employees[i];
                    worksheet.Cells[i + 2, 1].Value = employee.UId;
                    worksheet.Cells[i + 2, 2].Value = employee.Salutory;
                    worksheet.Cells[i + 2, 3].Value = employee.FirstName;
                    worksheet.Cells[i + 2, 4].Value = employee.MiddleName;
                    worksheet.Cells[i + 2, 5].Value = employee.LastName;
                    worksheet.Cells[i + 2, 6].Value = employee.NickName;
                    worksheet.Cells[i + 2, 7].Value = employee.Email;
                    worksheet.Cells[i + 2, 8].Value = employee.Mobile;
                    worksheet.Cells[i + 2, 9].Value = employee.EmployeeID;
                    worksheet.Cells[i + 2, 10].Value = employee.Role;
                    worksheet.Cells[i + 2, 11].Value = employee.ReportingManagerUId;
                    worksheet.Cells[i + 2, 12].Value = employee.ReportingManagerName;
                    worksheet.Cells[i + 2, 13].Value = employee.Address;
                }

                var stream = new System.IO.MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                var fileName = "ExportEmployeeBD";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

            }
        }

        //filter
        [HttpPost]
        public async Task<IActionResult> GetAllEmployeeByRole(string role)
        {
            var response = await _employeeService.GetAllEmployeeByRole(role);
            return Ok(response);
        }

        //pagination

        [HttpPost]
        public async Task <EmployeeFilterCriteria> GetAllEmployeeByPagination(EmployeeFilterCriteria employeeFilterCriteria)
        {
            var response = await _employeeService.GetAllEmployeeByPagination(employeeFilterCriteria);
            return response;
        }
    }
}
