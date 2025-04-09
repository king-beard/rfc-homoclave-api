using System.ComponentModel.DataAnnotations;
using RfcHomoclave.Middleware.Messages;

namespace RfcHomoclave.Middleware.Dtos.Common.Response
{
    public class FunctionalErrorMessageDto
    {
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public string Origin { get; set; }

        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public string Message { get; set; }

    }
}