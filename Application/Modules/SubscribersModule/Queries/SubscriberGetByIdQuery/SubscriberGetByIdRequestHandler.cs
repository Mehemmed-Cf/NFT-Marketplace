using Application.Repositories;
using MediatR;

namespace Application.Modules.SubscribersModule.Queries.SubscriberGetByIdQuery
{
    public class SubscriberGetByIdRequestHandler : IRequestHandler<SubscriberGetByIdRequest, SubscriberGetByIdRequestDto>
    {
        private readonly ISubscribersRepository subscribersRepository;

        public SubscriberGetByIdRequestHandler(ISubscribersRepository subscribersRepository)
        {
            this.subscribersRepository = subscribersRepository;
        }

        public async Task<SubscriberGetByIdRequestDto> Handle(SubscriberGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await subscribersRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            return new SubscriberGetByIdRequestDto
            {
                Id = entity.Id,
                Email = entity.Email,
            };
        }
    }
}
