using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery
{
    public class CreatorGetAllRequest : IRequest<IEnumerable<CreatorGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
