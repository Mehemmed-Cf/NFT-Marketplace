using Application.Repositories;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.UsersModule.Commands.UserEditCommand
{
    public class UserEditRequestHandler : IRequestHandler<UserEditRequest>
    {
        private readonly IUserRepository userRepository;

        public UserEditRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task Handle(UserEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await userRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            entity.Username = request.Username;
            entity.Email = request.Email;
            entity.Password = request.Password;
            entity.EmailConfirmed = request.EmailConfirmed.GetValueOrDefault(false);

            await userRepository.SaveAsync(cancellationToken);
        }
    }
}
