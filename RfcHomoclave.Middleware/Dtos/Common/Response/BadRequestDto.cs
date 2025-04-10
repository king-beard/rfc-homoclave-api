namespace RfcHomoclave.Middleware.Dtos.Common.Response
{
    public record BadRequestDto
    (
        string Type,
        string Title,
        int Status,
        string TraceId,
        Object Errors
    );
}