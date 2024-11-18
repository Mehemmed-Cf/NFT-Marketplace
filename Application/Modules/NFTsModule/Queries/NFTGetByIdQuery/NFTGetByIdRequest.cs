using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Queries.NFTGetByIdQuery
{
    public class NFTGetByIdRequest : IRequest<NFTGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
