
using Application.Repositories;
using MediatR;

namespace Application.Modules.CreatorsModule.Commands.CreatorFollowCommand
{
    public class CreatorFollowRequestHandler //: IRequestHandler<CreatorFollowRequest, CreatorFollowResponse>
    {
        private readonly ICreatorRepository creatorRepository;

        public CreatorFollowRequestHandler(ICreatorRepository creatorRepository)
        {
            this.creatorRepository = creatorRepository;
        }

        //public async Task<CreatorFollowResponse> Handle(CreatorFollowRequest request, CancellationToken cancellationToken)
        //{
        //    var creator = await creatorRepository.GetAsync(m => m.Id == request.CreatorId && m.DeletedAt == null, cancellationToken);


        //}
    }
}
