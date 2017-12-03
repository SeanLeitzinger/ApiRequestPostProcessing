using ApiRequestPostProcess.Core.Models;
using ApiRequestPostProcessing.Api.ResponseStrategies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRequestPostProcessing.Api.Filters
{
    public class ResponseFilter : ActionFilterAttribute
    {
        IUserResponseStrategyFactory userResponseStrategyFactory;

        public ResponseFilter(IUserResponseStrategyFactory userResponseStrategyFactory)
        {
            this.userResponseStrategyFactory = userResponseStrategyFactory;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var userTypeHeader = context.HttpContext.Request.Headers.SingleOrDefault(m => m.Key == "UserType").Value.FirstOrDefault();

            if (!Enum.TryParse(userTypeHeader, out UserType userType))
                base.OnActionExecuted(context);

            if (context.Result is OkObjectResult)
            {
                var okResult = context.Result as OkObjectResult;

                dynamic userObject = null;

                if (okResult.DeclaredType == typeof(List<User>))
                    userObject = okResult.Value as List<User>;
                else if (okResult.DeclaredType == typeof(User))
                    userObject = okResult.Value as User;
                else
                    base.OnActionExecuted(context);

                var strategy = userResponseStrategyFactory.Create(userType);
                strategy.Execute(userObject);
            }

            base.OnActionExecuted(context);
        }
    }
}
