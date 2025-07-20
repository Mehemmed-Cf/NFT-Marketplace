using Application.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Modules.UsersModule.Commands.UserRemoveCommand
{
    public class UserRemoveRequestHandler : IRequestHandler<UserRemoveRequest>
    {
        private readonly IUserRepository userRepository;

        public UserRemoveRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Handle(UserRemoveRequest request, CancellationToken cancellationToken)
        {
            User entity;

            if(request.OnlyAvailable)
            {
                entity = await userRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);
            } 
            else
            {
                entity = await userRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            userRepository.Remove(entity);
            await userRepository.SaveAsync(cancellationToken);
        }
    }
}
