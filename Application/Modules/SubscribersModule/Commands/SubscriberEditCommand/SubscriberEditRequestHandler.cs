using Application.Repositories;
using MediatR;

namespace Application.Modules.SubscribersModule.Commands.SubscriberEditCommand
{
    public class SubscriberEditRequestHandler : IRequestHandler<SubscriberEditRequest>
    {
        private readonly ISubscribersRepository subscribersRepository;

        public SubscriberEditRequestHandler(ISubscribersRepository subscribersRepository)
        {
            this.subscribersRepository = subscribersRepository;
        }

        public async Task Handle(SubscriberEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await subscribersRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            entity.Email = request.Email;

            await subscribersRepository.SaveAsync(cancellationToken);
        }
    }
}
