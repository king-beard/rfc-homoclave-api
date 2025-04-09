using RfcHomoclave.Middleware.Contracts.Services;
using RfcHomoclave.Service.Services;

namespace RfcHomoclave.Service
{
    public class ServiceFactory : IServiceFactory
    {
        private IRfcHomoclaveService rfcHomoclaveService;

        public IRfcHomoclaveService RfcHomoclaveService => rfcHomoclaveService ??= new RfcHomoclaveService();
    }
}
