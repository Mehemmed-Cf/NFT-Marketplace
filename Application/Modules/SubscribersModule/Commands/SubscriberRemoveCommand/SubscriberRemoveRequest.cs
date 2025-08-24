using MediatR;

namespace Application.Modules.SubscribersModule.Commands.SubscriberRemoveCommand
{
    public class SubscriberRemoveRequest : IRequest
    {
        public int Id { get; set; }
        public bool OnlyAvailable { get; set; } = true;
    }
}
