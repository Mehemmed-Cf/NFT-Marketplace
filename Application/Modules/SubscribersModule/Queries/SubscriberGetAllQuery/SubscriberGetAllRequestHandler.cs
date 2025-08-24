using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.SubscriberModule.Queries.SubscribersGetAllQuery
{
    public class SubscriberGetAllRequestHandler : IRequestHandler<SubscriberGetAllRequest, IEnumerable<SubscriberGetAllRequestDto>>
    {
        private readonly ISubscribersRepository subscribersRepository;

        public SubscriberGetAllRequestHandler(ISubscribersRepository subscribersRepository)
        {
            this.subscribersRepository = subscribersRepository;
        }

        public async Task<IEnumerable<SubscriberGetAllRequestDto>> Handle(SubscriberGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = subscribersRepository.GetAll();

            if(request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            var queryResponse = await query.Select(m => new SubscriberGetAllRequestDto
            {
                Id = m.Id,
                Email = m.Email,
            }).ToListAsync(cancellationToken);

            return queryResponse;
        }
    }
}
