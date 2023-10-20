using Microsoft.AspNetCore.Mvc;
using CarrierPidgeon.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CarrierPidgeon.Services.Responses{
    public class BadRequestModelStateResponse{
        public static IActionResult BadRequestModelState(ModelStateDictionary modelState)
        {
            IEnumerable<string> errorMessages = modelState.Values.SelectMany(values => values.Errors.Select(error => error.ErrorMessage));

            return new BadRequestObjectResult(new ErrorResponse(errorMessages));
        }
    }
}