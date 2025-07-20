using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.UsersModule.Queries.UserGetAllQuery
{
    public class UserGetAllRequest : IRequest<IEnumerable<UserGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
