namespace RfcHomoclave.Middleware.Dtos.Common.Request
{
    public record RfcHomoclaveReqDto
    (
         string Name,
         string FathersLastName,
         string MothersLastName,
         string BirthdayDate ,
         string PersonType
    );
}
