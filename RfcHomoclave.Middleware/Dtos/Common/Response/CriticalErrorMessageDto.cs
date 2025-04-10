using RfcHomoclave.Middleware.Messages;
using System.ComponentModel.DataAnnotations;

namespace RfcHomoclave.Middleware.Dtos.Common.Response
{
    public record CriticalErrorMessageDto
    (
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        string Origin,
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        IEnumerable<string> Message,
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        string TrackingCode
    );
}