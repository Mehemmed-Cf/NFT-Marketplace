using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.NFTsModule.Commands.NFTRemoveCommand
{
    public class NFTRemoveRequest : IRequest
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
