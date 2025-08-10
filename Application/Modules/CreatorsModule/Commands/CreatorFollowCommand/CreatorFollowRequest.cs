
using MediatR;

namespace Application.Modules.CreatorsModule.Commands.CreatorFollowCommand
{
    public class CreatorFollowRequest : IRequest<CreatorFollowResponse>
    {
        public int CreatorId { get; set; }
        public string UserId { get; set; } = "test-user-id";
    }
}
