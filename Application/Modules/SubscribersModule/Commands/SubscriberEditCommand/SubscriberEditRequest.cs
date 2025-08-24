using MediatR;

namespace Application.Modules.SubscribersModule.Commands.SubscriberEditCommand
{
    public class SubscriberEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
