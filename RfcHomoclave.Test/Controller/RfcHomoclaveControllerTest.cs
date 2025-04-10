using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using RfcHomoclave.API.Controllers.rfc_homoclave;
using RfcHomoclave.Middleware.Contracts.Services;
using Req = RfcHomoclave.Middleware.Dtos.Common.Request;

namespace RfcHomoclave.Test.Controller
{
    public class RfcHomoclaveControllerTest
    {
        private readonly IServiceFactory serviceFactory;
        public RfcHomoclaveControllerTest()
        {
            serviceFactory = A.Fake<IServiceFactory>();
        }

        [Fact]
        public void RfcHomoclaveControllerCalculateRfc()
        {
            //Arrange
            Req.RfcHomoclaveReqDto request = A.Fake<Req.RfcHomoclaveReqDto>();
            RfcHomoclaveController controller = new(serviceFactory);

            //Act
            ActionResult result = controller.GenerateRfcHomoclave(request);
            OkObjectResult okObjectResult = result as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

            okObjectResult.Value.Should().NotBeNull();
            okObjectResult.StatusCode.Should().Be(200);
        }
    }
}
