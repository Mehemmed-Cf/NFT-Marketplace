using Application.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Modules.SubscribersModule.Commands.SubscriberAddCommand
{
    public class SubscriberAddRequestHandler : IRequestHandler<SubscriberAddRequest, SubscriberAddRequestDto>
    {
        private readonly ISubscribersRepository subscribersRepository;

        public SubscriberAddRequestHandler(ISubscribersRepository subscribersRepository)
        {
            this.subscribersRepository = subscribersRepository;
        }

        public async Task<SubscriberAddRequestDto> Handle(SubscriberAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Subscriber
            {
                Id = request.Id,
                Email = request.Email,
            };

            await subscribersRepository.AddAsync(entity);
            await subscribersRepository.SaveAsync(cancellationToken);

            var dto = new SubscriberAddRequestDto
            {
                Id = entity.Id,
                Email = entity.Email,
            };

            return dto;
        }
    }
}
