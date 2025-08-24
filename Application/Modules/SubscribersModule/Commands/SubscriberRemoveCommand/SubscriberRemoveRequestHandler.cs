using Application.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Modules.SubscribersModule.Commands.SubscriberRemoveCommand
{
    public class SubscriberRemoveRequestHandler : IRequestHandler<SubscriberRemoveRequest>
    {
        private readonly ISubscribersRepository subscribersRepository;

        public SubscriberRemoveRequestHandler(ISubscribersRepository subscribersRepository)
        {
            this.subscribersRepository = subscribersRepository;
        }

        public async Task Handle(SubscriberRemoveRequest request, CancellationToken cancellationToken)
        {
            Subscriber entity;

            if(request.OnlyAvailable)
            {
                entity = await subscribersRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);
            } 
            else
            {
                entity = await subscribersRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            subscribersRepository.Remove(entity);
            await subscribersRepository.SaveAsync(cancellationToken);
        }
    }
}
