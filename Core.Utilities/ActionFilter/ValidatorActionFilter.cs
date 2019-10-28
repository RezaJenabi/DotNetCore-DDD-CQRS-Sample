using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.ResponseWrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Utilities.ActionFilter
{
    public class ValidatorActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage)
                    .ToList();

                var responseObj = new
                {
                    Message = "Bad Request",
                    Errors = errors
                };
                //TODO:I cant come back result by APIResponse
                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = 400
                }; ;
            }
        }
    }
}
