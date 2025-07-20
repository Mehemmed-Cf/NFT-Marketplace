using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.UsersModule.Queries.UserGetByIdQuery
{
    public class UserGetByIdRequest : IRequest<UserGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
