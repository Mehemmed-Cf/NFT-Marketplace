using MediatR;

namespace Application.Modules.UsersModule.Commands.UserAddCommand
{
    public class UserAddRequest : IRequest<UserAddRequestDto>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
