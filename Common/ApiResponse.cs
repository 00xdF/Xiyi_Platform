namespace Xiyi_Platform.Common
{
    //添加API响应规范
    public static class ApiResponse
    {
        public static ResponseFormat Ok(Object obj)
        {
            return new ResponseFormat
            {
                Status = 200,
                Body = obj
            };

        }
        public static ResponseFormat NotFound(Object obj)
        {
            return new ResponseFormat
            {
                Status = 404,
                Body = obj
            };
        }
        public static ResponseFormat NotAuth(Object obj)
        {
            return new ResponseFormat
            {
                Status = 401,
                Body = obj
            };
        }
        public static ResponseFormat BadRequest(Object obj)
        {
            return new ResponseFormat
            {
                Status = 500,
                Body = obj
            };
        }
    }
}
