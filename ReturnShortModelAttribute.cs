using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using Enumerable = System.Linq.Enumerable;

namespace EyeRide.FMS.Web.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ReturnShortModelAttribute : ActionFilterAttribute
    {
        public ReturnShortModelAttribute(Type model, params Type[] models)
        {
            if (models != null && models.Any())
            {
                Models = Enumerable.ToArray(Enumerable.Concat(models, new[] { model, }));
            }
            else
            {
                Models = new[] { model, };
            }
        }

        public Type[] Models { get; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var content = actionExecutedContext?.Response?.Content as ObjectContent;

            if (!(content?.Formatter is JsonMediaTypeFormatter))
            {
                return;
            }

            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings =
                {
                    ContractResolver = new ShouldSerializeContractResolver(Models),
                },
            };

            actionExecutedContext.Response.Content = new ObjectContent(content.ObjectType, content.Value, formatter);
        }
    }
}