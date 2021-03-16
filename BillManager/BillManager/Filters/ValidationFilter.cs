using Contracts.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillManager.Filters
{
	public class ValidationFilter : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if(!context.ModelState.IsValid)
			{
				var errorsInModelState = context.ModelState
					.Where(e => e.Value.Errors.Count > 0)
					.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)).ToArray();

				var errorResponse = new ErrorResponse();

				foreach(var error in errorsInModelState)
				{
					foreach(var subError in error.Value)
					{
						var errorModel = new ErrorModel
						{
							fieldName = error.Key,
							Error = subError
						};
						
						errorResponse.Errors.Add(errorModel);
					}

					context.Result = new BadRequestObjectResult(errorResponse);
					return;
				}
			}
			await next();
		}
	}
}
