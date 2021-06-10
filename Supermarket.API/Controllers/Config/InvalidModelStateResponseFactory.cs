using Microsoft.AspNetCore.Mvc;
using Supermarket.API.DataTransferObjects;
using Supermarket.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers.Config
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorDto(messages: errors);

            return new BadRequestObjectResult(response);
        }
    }
}
