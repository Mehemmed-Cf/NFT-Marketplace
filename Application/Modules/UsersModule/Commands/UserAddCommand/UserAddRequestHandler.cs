using Application.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Modules.UsersModule.Commands.UserAddCommand
{
    public class UserAddRequestHandler : IRequestHandler<UserAddRequest, UserAddRequestDto>
    {
        public IUserRepository userRepository;

        public UserAddRequestHandler(IUserRepository userRepository )
        {
            this.userRepository = userRepository;
        }

        public async Task<UserAddRequestDto> Handle(UserAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
            };

            await userRepository.AddAsync(entity);
            await userRepository.SaveAsync(cancellationToken);

            var dto = new UserAddRequestDto
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password,
                EmailConfirmed = entity.EmailConfirmed.GetValueOrDefault(false)
            };

            return dto;
        }
    }
}
