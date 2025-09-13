using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.UsersModule.Queries.UserGetAllQuery
{
    public class UserGetAllRequestHandler : IRequestHandler<UserGetAllRequest, IEnumerable<UserGetAllRequestDto>>
    {
        private readonly IUserRepository userRepository;
        private readonly DbContext db;

        public UserGetAllRequestHandler(IUserRepository userRepository, DbContext db)
        {
            this.userRepository = userRepository;
            this.db = db;
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

            //var users = await db.LegacyUsers
            //    .Select(u => new UserGetAllRequestDto
            //    {
            //        Id = u.UserId,
            //        Username = u.UserName,
            //        Email = u.Email,
            //        Password = null, // Legacy hashed or encrypted
            //        EmailConfirmed = u.IsApproved // or other mapping
            //    })
            //    .ToListAsync();
            //return users;

        }
    }
}
