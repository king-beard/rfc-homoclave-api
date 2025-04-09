using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RfcHomoclave.Middleware.Contracts.Services;
using RfcHomoclave.Middleware.Exceptions;
using RfcHomoclave.Middleware.Helpers.Constants;
using RfcHomoclave.Middleware.Messages;
using Res = RfcHomoclave.Middleware.Dtos.Common.Response;

namespace RfcHomoclave.API.Controllers.rfc_homoclave
{
    [ApiController]
    [Produces(ControllerConst.ContentType)]
    [Route(ControllerConst.RfcHomoclaveRoute, Name = ControllerConst.RfcHomoclaveName)]
    public class RfcController(IServiceFactory serviceFactory) : BaseController(serviceFactory)
    {

        /// <summary>
        /// Test if service is work return date to now, and version about service
        /// </summary>
        /// <returns></returns>
        /// <Response code="200">Show Ok(200)</Response>
        /// <Response code="500">Show the error data with the exception code</Response>
        [AllowAnonymous]
        [HttpGet(ControllerConst.Test)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Res.BadRequestDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Res.FunctionalErrorMessageDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(Res.CriticalErrorMessageDto), StatusCodes.Status500InternalServerError)]
        public ActionResult Test()
        {
            ActionResult Result;
            try
            {
                return Ok(new { date = DateTime.Now, version = "1.0" });
            }
            catch (BusinessException capex)
            {
                if (capex.Message.Contains(MessageServices.OKResponseGenerate204))
                    Result = NoContent();
                else
                    Result = Conflict(new Res.FunctionalErrorMessageDto { Origin = ControllerConst.OriginService, Message = capex.Message });
            }
            catch (Exception ex)
            {
                Result = StatusCode(StatusCodes.Status500InternalServerError, new Res.CriticalErrorMessageDto { Origin = ControllerConst.OriginService, Message = new[] { MessageServices.InternalServerError }, TrackingCode = ex.Message });
            }
            return Result;
        }
    }
}
