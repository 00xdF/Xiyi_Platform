using System.Net;

namespace Xiyi_Platform.Common.Extension
{
    public static class GetRemoteIPAddress
    {

        public static IPAddress? GetRemoteIP(this HttpContext context, bool allowForwarded = true)
        {
            if (allowForwarded)
            {
                var header = context.Request.Headers["CF-Connecting-IP"].FirstOrDefault()
                             ?? context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (IPAddress.TryParse(header, out var ip))
                {
                    return ip;
                }
            }

            return context.Connection.RemoteIpAddress;
        }
    }
}
