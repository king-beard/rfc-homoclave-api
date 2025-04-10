using System.ComponentModel.DataAnnotations;
using RfcHomoclave.Middleware.Messages;

namespace RfcHomoclave.Middleware.Dtos.Common.Response
{
    public record FunctionalErrorMessageDto
    (
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        string Origin,
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        string Message
    );
}