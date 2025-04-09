namespace RfcHomoclave.Middleware.Dtos.Common.Response
{
    public class BadRequestDto
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Object Errors { get; set; }
    }
}