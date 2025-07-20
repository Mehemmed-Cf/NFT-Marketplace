using Application.Repositories;
using MediatR;

namespace Application.Modules.UsersModule.Queries.UserGetByIdQuery
{
    public class UserGetByIdRequestHandler : IRequestHandler<UserGetByIdRequest, UserGetByIdRequestDto>
    {
        private readonly IUserRepository userRepository;

        public UserGetByIdRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserGetByIdRequestDto> Handle(UserGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await userRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            return new UserGetByIdRequestDto
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password,
                EmailConfirmed = entity.EmailConfirmed,
            };
        }
    }
}
