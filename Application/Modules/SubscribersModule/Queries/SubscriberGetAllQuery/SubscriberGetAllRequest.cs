using MediatR;

namespace Application.Modules.SubscriberModule.Queries.SubscribersGetAllQuery
{
    public class SubscriberGetAllRequest : IRequest<IEnumerable<SubscriberGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
