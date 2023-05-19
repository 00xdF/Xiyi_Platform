using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using Xiyi_Platform.Common;

namespace Xiyi_Platform.Filter
{
    public class UnauthorizedExpectionHandle : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
             await next();
        }
    }
}


