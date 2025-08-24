using MediatR;

namespace Application.Modules.SubscribersModule.Commands.SubscriberAddCommand
{
    public class SubscriberAddRequest : IRequest<SubscriberAddRequestDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
