using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Queries.CreatorGetByIdQuery
{
    public class CreatorGetByIdRequest : IRequest<CreatorGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
    