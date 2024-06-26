using EmployeeManagementSystemAssignment_Ruchika.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSystemAssignment_Ruchika.ServiceFilters
{
    public class BuildEmployeeAdditionalaDetailFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(x => x.Value is EmployeeADFilterCriteria);
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }

            EmployeeADFilterCriteria filterCriteria = (EmployeeADFilterCriteria)param.Value;
            var statusFilter = filterCriteria.Filters.Find(a => a.FieldName == "status");
            if (statusFilter == null)
            {
                statusFilter = new FilterCriteriaAD();
                statusFilter.FieldName = "status";
                statusFilter.FieldValue = "Active";
                filterCriteria.Filters.Add(statusFilter);
            }

            filterCriteria.Filters.RemoveAll(a => string.IsNullOrEmpty(a.FieldName));

            var result = await next();
        }
    }
}
