using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.UsersModule.Queries.UserGetAllQuery
{
    public class UserGetAllRequestHandler : IRequestHandler<UserGetAllRequest, IEnumerable<UserGetAllRequestDto>>
    {
        private readonly IUserRepository userRepository;

        public UserGetAllRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<UserGetAllRequestDto>> Handle(UserGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = userRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var queryResponse = await query.Select(m => new UserGetAllRequestDto
            {
                Id = m.Id,
                Username = m.Username,
                Email = m.Email,
                Password = m.Password,
                EmailConfirmed = m.EmailConfirmed,
            }).ToListAsync(cancellationToken);

            return queryResponse;
        }
    }
}
