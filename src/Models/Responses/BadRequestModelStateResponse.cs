using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarrierPidgeon.Models.Responses{
    public class BadRequestModelStateResponse{
        public static IActionResult BadRequestModelState(ModelStateDictionary modelState)
        {
            IEnumerable<string> errorMessages = modelState.Values.SelectMany(values => values.Errors.Select(error => error.ErrorMessage));

            return new BadRequestObjectResult(new ErrorResponse(errorMessages));
        }
    }
}