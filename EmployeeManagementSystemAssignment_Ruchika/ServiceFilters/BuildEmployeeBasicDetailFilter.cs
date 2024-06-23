using EmployeeManagementSystemAssignment_Ruchika.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementSystemAssignment_Ruchika.ServiceFilters
{
    public class BuildEmployeeBasicDetailFilter : IAsyncActionFilter

    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var param = context.ActionArguments.SingleOrDefault(x => x.Value is EmployeeFilterCriteria);
            if(param.Value == null)
            {
                context.Result = new BadRequestObjectResult("Object is null");
                return;
            }

            EmployeeFilterCriteria filterCriteria = (EmployeeFilterCriteria)param.Value;
            var roleFilter = filterCriteria.Filters.Find(a => a.FieldName == "role");
            if(roleFilter == null)
            {
                roleFilter = new FilterCriteria();
                roleFilter.FieldName = "role";
                roleFilter.FieldValue = "HR";
                filterCriteria.Filters.Add(roleFilter);
            }

            filterCriteria.Filters.RemoveAll(a => string.IsNullOrEmpty(a.FieldName));

            var result = await next();
        }
    }
}
