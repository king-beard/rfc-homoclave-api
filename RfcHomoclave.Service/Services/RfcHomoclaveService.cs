using RfcHomoclave.Middleware.Contracts.Services;
using RfcHomoclave.Middleware.Helpers.RfcHomoclave;
using Req = RfcHomoclave.Middleware.Dtos.Common.Request;
using Res = RfcHomoclave.Middleware.Dtos.Common.Response;

namespace RfcHomoclave.Service.Services
{
    public class RfcHomoclaveService : IRfcHomoclaveService
    {
        public Res.RfcHomoclaveResDto Generate(Req.RfcHomoclaveReqDto request)
        {
            string fathersLastName = request.FathersLastName.ToUpper().RemoveAccents();
            string mothersLastName = request.MothersLastName.ToUpper().RemoveAccents();
            string name = request.Name.ToUpper().RemoveAccents();

            string rfcWithOutHomoclave = RfcHomoclaveParts.GenerateRfcWithOutHomoclave(fathersLastName, mothersLastName, name, DateTime.Parse(request.BirthdayDate), request.PersonType);
            string fullName = $"{fathersLastName} {mothersLastName} {name}";

            string rfcHomonimiakey = RfcHomoclaveParts.HomonimiaKey(rfcWithOutHomoclave, fullName);
            string digitVerify = RfcHomoclaveParts.DigitVerify(rfcHomonimiakey);

            return new Res.RfcHomoclaveResDto($"{rfcHomonimiakey}{digitVerify}");
        }
    }
}
