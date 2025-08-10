using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Commands.CreatorFollowCommand
{
    public class CreatorFollowResponse
    {
        public bool IsFollowing { get; set; }
        public int FollowCount { get; set; }
    }
}
