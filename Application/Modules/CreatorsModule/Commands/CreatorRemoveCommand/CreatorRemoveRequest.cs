using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Commands.CreatorRemoveCommand
{
    public class CreatorRemoveRequest : IRequest
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
