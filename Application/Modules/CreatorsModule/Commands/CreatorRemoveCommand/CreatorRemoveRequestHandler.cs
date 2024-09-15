using Application.Repositories;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Commands.CreatorRemoveCommand
{
    public class CreatorRemoveRequestHandler : IRequestHandler<CreatorRemoveRequest>
    {
        private readonly ICreatorRepository creatorRepository;

        public CreatorRemoveRequestHandler(ICreatorRepository creatorRepository)
        {
            this.creatorRepository = creatorRepository;
        }

        public async Task Handle(CreatorRemoveRequest request, CancellationToken cancellationToken)
        {
            Creator entity;

            if(request.OnlyAvailable)
            {
                entity = await creatorRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);
            } else
            {
                entity = await creatorRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            creatorRepository.Remove(entity);
            await creatorRepository.SaveAsync(cancellationToken);
        }
    }
}
