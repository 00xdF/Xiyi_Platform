using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Xiyi_Platform.Common;

public class UnAutorizeHandle
{
    private readonly RequestDelegate _next;

    public UnAutorizeHandle(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine(context.Response.StatusCode);
        if (context.Response.StatusCode == 401)
        {
            Debug.WriteLine("401");
            Console.WriteLine("401");
            Trace.WriteLine("401");
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(ApiResponse.NotAuth("未登录！")));
            return;
        }

        await _next(context);
    }
}