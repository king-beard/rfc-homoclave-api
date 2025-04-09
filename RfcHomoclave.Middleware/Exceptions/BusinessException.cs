namespace RfcHomoclave.Middleware.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
        public BusinessException(string message, Exception exception) : base(message, exception) { }
    }
}
