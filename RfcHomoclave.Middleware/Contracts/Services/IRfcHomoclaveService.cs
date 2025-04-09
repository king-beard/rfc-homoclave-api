using Req = RfcHomoclave.Middleware.Dtos.Common.Request;
using Res = RfcHomoclave.Middleware.Dtos.Common.Response;

namespace RfcHomoclave.Middleware.Contracts.Services
{
    public interface IRfcHomoclaveService
    {
        Res.RfcHomoclaveResDto Generate(Req.RfcHomoclaveReqDto request);
    }
}
