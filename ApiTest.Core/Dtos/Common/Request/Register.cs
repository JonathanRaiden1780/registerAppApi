using System.ComponentModel.DataAnnotations;
using ApiTest.Core.Messages;

namespace ApiTest.Core.Dtos.Common.Request
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public string name { get; set; }
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public string email { get; set; }
        [Required(ErrorMessageResourceName = nameof(MessagesDataAnnotations.Required), ErrorMessageResourceType = typeof(MessagesDataAnnotations))]
        public int age { get; set; }
        
    }
}
