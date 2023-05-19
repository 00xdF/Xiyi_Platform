namespace Xiyi_Platform.Common
{
    public class ResponseFormat
    {
        public  int Status { get; set; }
        public object Body { get; set; }
        public ResponseFormat(int status,object body)
        {
            this.Status = status;
            this.Body = body;
        }
        public ResponseFormat()
        {

        }
    }
}
