using Application.Modules.CreatorsModule.Queries.CreatorGetAllQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Queries.NFTGetAllQuery
{
    public class NFTGetAllRequest : IRequest<IEnumerable<NFTGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
