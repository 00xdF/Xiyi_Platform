using System.Net;
using Xiyi_Platform.Common;
using Xiyi_Platform.Common.Extension;
using Xiyi_Platform.Entities;
using Xiyi_Platform.UoW;

namespace Xiyi_Platform.MiddleWare
{

    //利用中间件捕获所有请求 实现访客记录
    public class VisitorRecord
    {
        private readonly RequestDelegate _next;

        public VisitorRecord(RequestDelegate next)
        {
            _next = next;
        }

        public  Task Invoke(HttpContext context, UnitOfWork uow)
        {
            var request = context.Request;
            var response = context.Response;
            var visitor = new Visitor
            {
                RequestMethod = request.Method,
                IP = context.GetRemoteIP()?.ToString().Split(":")?.Last(),
                RequestUrl = request.Path,
                UserAgent = request.Headers.UserAgent
            };
            uow.DBContext.Visitors.AddAsync(visitor);
            uow.Commit();
            return _next(context);
        }

    }
}
