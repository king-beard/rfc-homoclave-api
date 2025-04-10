using RfcHomoclave.Middleware.Messages;
using System.ComponentModel.DataAnnotations;

namespace RfcHomoclave.Middleware.Dtos.Common.Request
{
    public record RfcHomoclaveReqDto
    (
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
         string Name,
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
         string FathersLastName,
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
         string MothersLastName,
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
         string BirthdayDate ,
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
         string PersonType
    );
}
