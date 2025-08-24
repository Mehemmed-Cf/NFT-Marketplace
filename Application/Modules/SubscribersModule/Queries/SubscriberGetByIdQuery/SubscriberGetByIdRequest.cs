using MediatR;

namespace Application.Modules.SubscribersModule.Queries.SubscriberGetByIdQuery
{
    public class SubscriberGetByIdRequest : IRequest<SubscriberGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
