using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Application.Modules.AccountsModule.Commands.SignUpCommand
{
    public class SignUpRequest : IRequest<ClaimsPrincipal>
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
