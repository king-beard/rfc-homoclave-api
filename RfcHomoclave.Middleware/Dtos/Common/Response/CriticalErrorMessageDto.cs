using System.ComponentModel.DataAnnotations;
using RfcHomoclave.Middleware.Messages;

namespace RfcHomoclave.Middleware.Dtos.Common.Response
{
    public class CriticalErrorMessageDto
    {
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public string Origin { get; set; }

        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public IEnumerable<string> Message { get; set; }
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public string TrackingCode { get; set; }
    }
}