using Microsoft.AspNetCore.Mvc;
using RfcHomoclave.Middleware.Contracts.Services;

namespace RfcHomoclave.API.Controllers
{
    public class BaseController(IServiceFactory serviceFactory) : Controller
    {
        protected readonly IServiceFactory serviceFactory = serviceFactory;
    }
}
