using AutoMapper;
using EmployeeManagementSystemAssignment_Ruchika.CosmosDB;
using EmployeeManagementSystemAssignment_Ruchika.Entities;
using EmployeeManagementSystemAssignment_Ruchika.Interface;
using EmployeeManagementSystemAssignment_Ruchika.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAssignment_Ruchika.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly ICosmosDBService _cosmosDBService;

        public readonly IMapper _mapper;

        public EmployeeService(ICosmosDBService cosmosDBService, IMapper mapper)
        {
            _cosmosDBService = cosmosDBService;
            _mapper = mapper;
        }

        //EmployeeBasic details

        public async Task<EmployeeBDModel> AddEmployeeBD(EmployeeBDModel employeeBDModel)
        {
            EmployeeBDEntity employee = new EmployeeBDEntity();

            employee.Salutory = employeeBDModel.Salutory;
            employee.FirstName = employeeBDModel.FirstName;
            employee.MiddleName = employeeBDModel.MiddleName;
            employee.LastName = employeeBDModel.LastName;
            employee.NickName = employeeBDModel.NickName;
            employee.Email = employeeBDModel.Email;
            employee.Mobile = employeeBDModel.Mobile;
            employee.EmployeeID = employeeBDModel.EmployeeID;
            employee.Role = employeeBDModel.Role;
            employee.ReportingManagerUId = employeeBDModel.ReportingManagerUId;
            employee.ReportingManagerName = employeeBDModel.ReportingManagerName;
            employee.Address = employeeBDModel.Address;

            employee.Intialize(true, "employeeBD", "Ruchika", "Ruchika");

            var response = await _cosmosDBService.AddEmployeeBD(employee);

            var responseModel = new EmployeeBDModel();

            responseModel.UId = response.UId;
            responseModel.Salutory = response.Salutory;
            responseModel.FirstName = response.FirstName;
            responseModel.MiddleName = response.MiddleName;
            responseModel.LastName = response.LastName;
            responseModel.NickName = response.NickName;
            responseModel.Email = response.Email;
            responseModel.Mobile = response.Mobile;
            responseModel.EmployeeID = response.EmployeeID;
            responseModel.Role = response.Role;
            responseModel.ReportingManagerUId = response.ReportingManagerUId;
            responseModel.ReportingManagerName = response.ReportingManagerName;
            responseModel.Address = response.Address;

            return responseModel;

        }

        

        public async Task<List<EmployeeBDModel>> GetAllEmployeeBD()
        {
            var employees = await _cosmosDBService.GetAllEmployeeBD();

            var EmployeeModels = new  List <EmployeeBDModel>();
            foreach (var response in employees)
            {
                var responseModel = new EmployeeBDModel();
                responseModel.UId = response.UId;
                responseModel.Salutory = response.Salutory;
                responseModel.FirstName = response.FirstName;
                responseModel.MiddleName = response.MiddleName;
                responseModel.LastName = response.LastName;
                responseModel.NickName = response.NickName;
                responseModel.Email = response.Email;
                responseModel.Mobile = response.Mobile;
                responseModel.EmployeeID = response.EmployeeID;
                responseModel.Role = response.Role;
                responseModel.ReportingManagerUId = response.ReportingManagerUId;
                responseModel.ReportingManagerName = response.ReportingManagerName;
                responseModel.Address = response.Address;
                EmployeeModels.Add(responseModel);
            }
            return EmployeeModels;
             

        }

        public async Task<EmployeeBDModel> GetEmployeeBDByUId(string uId)
        {
            var employee = await _cosmosDBService.GetEmployeeBDByUId(uId);

            var employeeBDModel = new EmployeeBDModel();
            employeeBDModel.UId = employee.UId;
            employeeBDModel.Salutory = employee.Salutory;
            employeeBDModel.FirstName = employee.FirstName;
            employeeBDModel.MiddleName = employee.MiddleName;
            employeeBDModel.LastName = employee.LastName;
            employeeBDModel.NickName = employee.NickName;
            employeeBDModel.Email = employee.Email;
            employeeBDModel.Mobile = employee.Mobile;
            employeeBDModel.EmployeeID = employee.EmployeeID;
            employeeBDModel.Role = employee.Role;
            employeeBDModel.ReportingManagerUId = employee.ReportingManagerUId;
            employeeBDModel.ReportingManagerName = employee.ReportingManagerName;
            employeeBDModel.Address = employee.Address;

            return employeeBDModel;
        }

        public async Task<EmployeeBDModel> UpdateEmployeeBD(EmployeeBDModel employeeBDModel)
        {
            var existingEmployee = await _cosmosDBService.GetEmployeeBDByUId(employeeBDModel.UId);

            existingEmployee.Active = false;
            existingEmployee.Archived = true;

            await _cosmosDBService.ReplaceAsync(existingEmployee);

            existingEmployee.Intialize(false, "employeeBD", "ruchika", "ruchika");

            existingEmployee.Salutory = employeeBDModel.Salutory;
            existingEmployee.FirstName = employeeBDModel.FirstName;
            existingEmployee.MiddleName = employeeBDModel.MiddleName;
            existingEmployee.LastName = employeeBDModel.LastName;
            existingEmployee.NickName = employeeBDModel.NickName;
            existingEmployee.Email = employeeBDModel.Email;
            existingEmployee.Mobile = employeeBDModel.Mobile;
            existingEmployee.EmployeeID = employeeBDModel.EmployeeID;
            existingEmployee.Role = employeeBDModel.Role;
            existingEmployee.ReportingManagerUId = employeeBDModel.ReportingManagerUId;
            existingEmployee.ReportingManagerName = employeeBDModel.ReportingManagerName;
            existingEmployee.Address = employeeBDModel.Address;

            var response = await _cosmosDBService.AddEmployeeBD(existingEmployee);

            var responseModel = new EmployeeBDModel();
            responseModel.UId = response.UId;
            responseModel.Salutory = response.Salutory;
            responseModel.FirstName = response.FirstName;
            responseModel.MiddleName = response.MiddleName;
            responseModel.LastName = response.LastName;
            responseModel.NickName = response.NickName;
            responseModel.Email = response.Email;
            responseModel.Mobile = response.Mobile;
            responseModel.EmployeeID = response.EmployeeID;
            responseModel.Role = response.Role;
            responseModel.ReportingManagerUId = response.ReportingManagerUId;
            responseModel.ReportingManagerName = response.ReportingManagerName;
            responseModel.Address = response.Address;

            return responseModel;

        }

        public async Task<string> DeleteEmployeeBD(string uId)
        {
            var employee = await _cosmosDBService.GetEmployeeBDByUId(uId);

            employee.Active = false;
            employee.Archived = true;

            await _cosmosDBService.ReplaceAsync(employee);

            employee.Intialize(false, "employee", "ruchika", "ruchika");
            employee.Active = false;

            await _cosmosDBService.AddEmployeeBD(employee);

            return "Record is deleted successfully....";
        }

        // Employee aditional details
        public async Task<EmployeeADModel> AddEmployeeAD(EmployeeADModel employeeADModel)
        {
            
          var employee = _mapper.Map<EmployeeADEntity>(employeeADModel);
          
            employee.Intialize(true, "employeeAD", "ruchika", "ruchika");

            var response = await _cosmosDBService.AddEmployeeAD(employee);

             var responseModel = _mapper.Map<EmployeeADModel>(response);
            
            return responseModel;

        }

        public async Task<List<EmployeeADModel>> GetAllEmployeeAD()
        {
            var employees = await _cosmosDBService.GetAllEmployeeAD();

            var employeeADModel = new List<EmployeeADModel>();
            
            foreach (var employee in employees)
            {
                var responseModel = _mapper.Map<EmployeeADModel>(employee);
                employeeADModel.Add(responseModel);

            }
            return employeeADModel;

        }

        public async Task<EmployeeADModel> GetEmployeeADByUId(string EmployeeBDUId)
        {
            var employee = await _cosmosDBService.GetEmployeeADByUId(EmployeeBDUId);
            var employeeADModel = _mapper.Map<EmployeeADModel>(employee);
            return employeeADModel;

        }

        public async Task<EmployeeADModel> UpdateEmployeeAD(EmployeeADModel employeeADModel)
        {
            var existingEmployee = await _cosmosDBService.GetEmployeeADByUId(employeeADModel.EmployeeBDUId);
            existingEmployee.Active = false;
            existingEmployee.Archived = true;

            await _cosmosDBService.ReplaceAsync(existingEmployee);

            existingEmployee.Intialize(false, "employeeAD", "ruchika", "ruchika");

            _mapper.Map(employeeADModel, existingEmployee);

            var response = await _cosmosDBService.AddEmployeeAD(existingEmployee);

            return _mapper.Map<EmployeeADModel>(response);



        }

        public async Task<string> DeleteEmployeAD(string EmployeeBDUId)
        {
            var employee = await _cosmosDBService.GetEmployeeADByUId(EmployeeBDUId);
            employee.Active = false;
            employee.Archived = true;

            await _cosmosDBService.ReplaceAsync(employee);

            employee.Intialize(false, "employeeAD", "ruchika", "ruchika");
            employee.Active = false;

            await _cosmosDBService.AddEmployeeAD(employee);

            return "record is deleted successfully";

        }

        //filter
        public async Task<List<EmployeeBDModel>> GetAllEmployeeByRole(string role)
        {
            //get all employee
            var allEmployee = await GetAllEmployeeBD();

            //filter as per role

            var filteredList = allEmployee.FindAll(x => x.Role == role);
            return filteredList;
        }

        //pagination
        public async Task<EmployeeFilterCriteria> GetAllEmployeeByPagination(EmployeeFilterCriteria employeeFilterCriteria)
        {
            EmployeeFilterCriteria response = new EmployeeFilterCriteria();
            //filter = role
            var checkFilter = employeeFilterCriteria.Filters.Any(x => x.FieldName == "role");
            var role = "";
            if(checkFilter)
            {
                role = employeeFilterCriteria.Filters.Find(x => x.FieldName == "role").FieldValue;
            }

            var employees = await GetAllEmployeeBD();

            var filteredRecords = employees.FindAll(x => x.Role == role);

            response.totalCount = employees.Count;
            response.page = employeeFilterCriteria.page;
            response.pageSize = employeeFilterCriteria.pageSize;

            var skip = employeeFilterCriteria.pageSize * (employeeFilterCriteria.page - 1);

            employees = employees.Skip(skip).Take(employeeFilterCriteria.pageSize).ToList();

            foreach(var emp in employees)
            {
                response.employees.Add(emp);
            }
            return response;
        }
    }
}
